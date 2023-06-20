using Dapper;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Adapters.PostgreSQL.Repositories
{
    public class Pedido : IPedido
    {
        public IEnumerable<Modules.Domain.Entities.Pedido> List()
        {
            string queryOrder = "select * from pedido";
            string queryOrderItem = "select * from pedido_item";

            var orders = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Pedido>(queryOrder);
            var orderItems = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.PedidoItem>(queryOrderItem);

            orders.ToList().ForEach(order =>
            {
                order.Itens = orderItems.Where(w => w.PedidoId == order.Id);
            });

            return orders;
        }

        public IEnumerable<Modules.Domain.Entities.Pedido> ListByStatus(PedidoStatus status)
        {
            string queryOrder = "select * from pedido where status = @status";
            string queryOrderItem = "select * from pedido_item where pedido_id = any(@ids)";

            var orders = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.Pedido>(queryOrder,new { status = status });
            var orderItems = PostgreSQL.Database.Connection().Query<Modules.Domain.Entities.PedidoItem>(queryOrderItem, new
            {
                ids = orders.Select(s => s.Id).ToList()
            });

            orders.ToList().ForEach(order =>
            {
                order.Itens = orderItems.Where(w => w.PedidoId == order.Id);
            });

            return orders;
        }

        public bool Order(Modules.Domain.Entities.Pedido pedido)
        {
            string queryOrder = @"insert into pedido 
                                (cliente_id,anonimo,anonimo_identificador,pedido_status_id,valor,cliente_observacao,data) 
                                values 
                                (@cliente_id,@anonimo,@anonimo_identificador,@pedido_status_id,@valor,@cliente_observacao,now() AT TIME ZONE 'America/Sao_Paulo') RETURNING id";

            string queryOrderItem = @"insert into pedido_item 
                                    (pedido_id,produto_id,preco_unitario,quantidade) 
                                    values 
                                    (@pedido_id,@produto_id,@preco_unitario,@quantidade)";

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

                    transaction.Commit();
                    connection.Close();
                    return true;
                }
            }

        }
    }
}
