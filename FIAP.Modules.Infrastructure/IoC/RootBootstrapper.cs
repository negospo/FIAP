using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Modules.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            services.AddScoped<Modules.Domain.Repositories.ICliente, Adapters.PostgreSQL.Repositories.Cliente>();
            services.AddScoped<Modules.Domain.Repositories.IProduto, Adapters.PostgreSQL.Repositories.Produto>();
            services.AddScoped<Modules.Domain.Repositories.IPedido, Adapters.PostgreSQL.Repositories.Pedido>();

            services.AddScoped<Modules.Application.UseCases.IClienteUseCase, Modules.Application.UseCases.ClienteUseCase>();
            services.AddScoped<Modules.Application.UseCases.IProdutoUseCase, Modules.Application.UseCases.ProdutoUseCase>();
            services.AddScoped<Modules.Application.UseCases.IPedidoUseCase, Modules.Application.UseCases.PedidoUseCase>();
        }
    }
}
