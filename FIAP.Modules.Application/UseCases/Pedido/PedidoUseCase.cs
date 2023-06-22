using FIAP.Modules.Application.DTO.Pedido;
using FIAP.Modules.Domain.Enums;
using FIAP.Modules.Domain.Repositories;

namespace FIAP.Modules.Application.UseCases
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedido _pedidoRepository;
        private readonly IProduto _produtoRepository;


        public PedidoUseCase(IPedido pedidoRepository, IProduto produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<DTO.Pedido.Response> List()
        {
            var result = _pedidoRepository.List().Select(s => new DTO.Pedido.Response
            {
                Id = s.Id,
                Data = s.Data,
                ClienteId = s.ClienteId,
                Anonimo = s.Anonimo,
                AnonimoIdentificador = s.AnonimoIdentificador,
                ClienteObservacao = s.ClienteObservacao,
                PedidoStatusId = s.PedidoStatusId,
                Valor = s.Valor,
                Itens = s.Itens.Select(si => new DTO.PedidoItem.Response
                {
                    ProdutoId = si.ProdutoId,
                    Quantidade = si.Quantidade
                })
            });

            return result;
        }

        public IEnumerable<DTO.Pedido.Response> ListByStatus(PedidoStatus status)
        {
            var result = _pedidoRepository.ListByStatus(status).Select(s => new DTO.Pedido.Response
            {
                Id = s.Id,
                Data = s.Data,
                ClienteId = s.ClienteId,
                Anonimo = s.Anonimo,
                AnonimoIdentificador = s.AnonimoIdentificador,
                ClienteObservacao = s.ClienteObservacao,
                PedidoStatusId = s.PedidoStatusId,
                Valor = s.Valor,
                Itens = s.Itens.Select(si => new DTO.PedidoItem.Response
                {
                    ProdutoId = si.ProdutoId,
                    Quantidade = si.Quantidade
                })
            });

            return result;
        }

        public DTO.Pedido.Response Get(int id)
        {
            var result = _pedidoRepository.Get(id);
            if (result == null)
                return null;


            return new Response
            {
                Id = result.Id,
                Data = result.Data,
                ClienteId = result.ClienteId,
                Anonimo = result.Anonimo,
                AnonimoIdentificador = result.AnonimoIdentificador,
                ClienteObservacao = result.ClienteObservacao,
                PedidoStatusId = result.PedidoStatusId,
                Valor = result.Valor,
                Itens = result.Itens.Select(si => new DTO.PedidoItem.Response
                {
                    ProdutoId = si.ProdutoId,
                    Quantidade = si.Quantidade
                })
            };
        }

        public bool Order(DTO.Pedido.SaveRequest pedido)
        {
            string identifier = (pedido.Anonimo) ? Guid.NewGuid().ToString() : "";
           
            //Busca os produtos do pedido para poder pegar os valores unitarios
            var products = _produtoRepository.List().Where(w => pedido.Itens.Select(s => s.ProdutoId).Any(a => a == w.Id)).ToList();
            //Cria a lista de itens para o request
            var itemsRequest = pedido.Itens.Select(s => new Domain.Entities.PedidoItem.Request
            {
                ProdutoId = s.ProdutoId.Value,
                Quantidade = s.Quantidade.Value,
                PrecoUnitario = products.FirstOrDefault(f => f.Id == s.ProdutoId).Preco
            });
            //Soma o total do pedido
            decimal totalValue = itemsRequest.Select(s => s.PrecoUnitario * s.Quantidade).Sum();
            
            var request = new Domain.Entities.Pedido.Request
            {
                Anonimo = pedido.Anonimo,
                AnonimoIdentificador = identifier,
                ClienteId = pedido.ClienteId,
                PedidoStatusId = PedidoStatus.Recebido,
                ClienteObservacao = pedido.ClienteObservacao,
                Valor = totalValue,
                Itens = itemsRequest
            };

            return _pedidoRepository.Order(request);
        }

        public bool UpdateOrderStatus(int id, PedidoStatus status)
        {
            return _pedidoRepository.UpdateOrderStatus(id, status);
        }
    }
}
