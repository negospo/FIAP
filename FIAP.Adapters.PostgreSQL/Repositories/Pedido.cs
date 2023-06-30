using Dapper;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class Pedido : IPedido
    {
        /// <summary>
        /// Lista todos os pedisos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Modules.Domain.Entities.Pedido.Response> List()
        {
            string queryOrder = "select * from pedido";
            string queryOrderItem = "select * from pedido_item";
            string queryPaymnet = "select pedido_id, tipo_pagamento_id from pedido_pagamento";

            var orders = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Pedido.Response>(queryOrder);
            var orderItems = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.PedidoItem.Response>(queryOrderItem);
            var payments = PostgreSQL.Database.Connection().Query(queryPaymnet);


            orders.ToList().ForEach(order =>
            {
                order.Itens = orderItems.Where(w => w.PedidoId == order.Id);
            });

            orders.ToList().ForEach(order =>
            {
                order.TipoPagamento = (Modules.Domain.Enums.TipoPagamento)payments.First(w => w.pedido_id == order.Id).tipo_pagamento_id;
            });

            return orders;
        }

        /// <summary>
        /// Lista pedidos pelo status
        /// </summary>
        /// <param name="status">Status do pedido</param>
        public IEnumerable<Modules.Domain.Entities.Pedido.Response> ListByStatus(PedidoStatus status)
        {
            string queryOrder = "select * from pedido where pedido_status_id = @pedido_status_id";
            string queryOrderItem = "select * from pedido_item where pedido_id = any(@ids)";
            string queryPaymnet = "select pedido_id, tipo_pagamento_id from pedido_pagamento where pedido_id = any(@ids)";

            var orders = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Pedido.Response>(queryOrder,new { pedido_status_id = status });
            var orderItems = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.PedidoItem.Response>(queryOrderItem, new
            {
                ids = orders.Select(s => s.Id).ToList()
            });

            var payments = PostgreSQL.Database.Connection().Query(queryPaymnet, new
            {
                ids = orders.Select(s => s.Id).ToList()
            });


            orders.ToList().ForEach(order =>
            {
                order.Itens = orderItems.Where(w => w.PedidoId == order.Id);
            });

            orders.ToList().ForEach(order =>
            {
                order.TipoPagamento = (Modules.Domain.Enums.TipoPagamento)payments.First(w => w.pedido_id == order.Id).tipo_pagamento_id;
            });

            return orders;
        }

        /// <summary>
        /// Retorna uma pedido pelo id
        /// </summary>
        /// <param name="id">Id do pedido</param>
        public Modules.Domain.Entities.Pedido.Response Get(int id)
        {
            string queryOrder = "select * from pedido where id = @id";
            string queryOrderItem = "select * from pedido_item where pedido_id = @pedido_id";
            string queryPaymnet = "select tipo_pagamento_id from pedido_pagamento where pedido_id = @pedido_id";

            var order = PostgreSQL.Database.Connection().QueryFirstOrDefault<Modules.Domain.Entities.Pedido.Response>(queryOrder, new { id = id });
            if (order == null)
                return order;

            var orderItems = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.PedidoItem.Response>(queryOrderItem, new { pedido_id = order.Id});
            order.Itens = orderItems;

            var paymentType = PostgreSQL.Database.Connection().QueryFirst<Modules.Domain.Enums.TipoPagamento>(queryPaymnet, new { pedido_id = id });
            order.TipoPagamento = paymentType;

            return order;
        }

        /// <summary>
        /// Cria um pedido
        /// </summary>
        /// <param name="pedido">Dados do pedido</param>
        public bool Order(Modules.Domain.Entities.Pedido.Request pedido)
        {
            string queryOrder = @"insert into pedido 
                                (cliente_id,anonimo,anonimo_identificador,pedido_status_id,valor,cliente_observacao,data) 
                                values 
                                (@cliente_id,@anonimo,@anonimo_identificador,@pedido_status_id,@valor,@cliente_observacao,now() AT TIME ZONE 'America/Sao_Paulo') RETURNING id";

            string queryOrderItem = @"insert into pedido_item 
                                    (pedido_id,produto_id,preco_unitario,quantidade) 
                                    values 
                                    (@pedido_id,@produto_id,@preco_unitario,@quantidade)";

            string queryPaymentInsert = "insert into pedido_pagamento (pedido_id,tipo_pagamento_id,status,valor,codigo_transacao) values (@pedido_id,@tipo_pagamento_id,@status,@valor,@codigo_transacao)";

            using (var connection = Database.Connection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    //Salva o pedido
                    int id = transaction.Connection.ExecuteScalar<int>(queryOrder, new
                    {
                        cliente_id = pedido.ClienteId,
                        anonimo = pedido.Anonimo,
                        anonimo_identificador = pedido.AnonimoIdentificador,
                        pedido_status_id = pedido.PedidoStatusId,
                        valor = pedido.Valor,
                        cliente_observacao = pedido.ClienteObservacao
                    });
                    //Cria a lista de itens do pedido
                    var orderItems = pedido.Itens.Select(item => new
                    {
                        pedido_id = id,
                        produto_id = item.ProdutoId,
                        preco_unitario = item.PrecoUnitario,
                        quantidade = item.Quantidade
                    }).ToList();
                    //Salva os itens do pedido
                    transaction.Connection.Execute(queryOrderItem, orderItems);
                    //Salva dados de pagamento
                    transaction.Connection.Execute(queryPaymentInsert, new
                    {
                        pedido_id = id,
                        tipo_pagamento_id = pedido.DadosPagamento.TipoPagamentoId,
                        status = pedido.DadosPagamento.Status,
                        valor = pedido.DadosPagamento.Valor,
                        codigo_transacao = pedido.DadosPagamento.CodigoTransacao
                    });

                    transaction.Commit();
                    connection.Close();
                    return true;
                }
            }
        }

        /// <summary>
        /// Altera o status de uma pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <param name="status">Novo Status do pedido</param>
        /// <returns></returns>
        public bool UpdateOrderStatus(int id, Modules.Domain.Enums.PedidoStatus status)
        {
            string query = "update pedido set pedido_status_id = @pedido_status_id where id = @id";
            int affected =  PostgreSQL.Database.Connection().Execute(query, new
            {
                id = id,
                pedido_status_id = status
            });

            return affected > 0;
        }
    }
}
