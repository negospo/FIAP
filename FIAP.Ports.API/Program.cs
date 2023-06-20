using FIAP.Adapters.PostgreSQL.Repositories;
using FIAP.Modules.Application.UseCases;
using FIAP.Modules.Domain.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FIAP.Ports.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<Modules.Domain.Repositories.ICliente, Adapters.PostgreSQL.Repositories.Cliente>();
            builder.Services.AddScoped<Modules.Domain.Repositories.IProduto, Adapters.PostgreSQL.Repositories.Produto>();
            builder.Services.AddScoped<Modules.Domain.Repositories.IPedido, Adapters.PostgreSQL.Repositories.Pedido>();

            builder.Services.AddScoped<Modules.Application.UseCases.IClienteUseCase, Modules.Application.UseCases.ClienteUseCase>();
            builder.Services.AddScoped<Modules.Application.UseCases.IProdutoUseCase, Modules.Application.UseCases.ProdutoUseCase>();
            builder.Services.AddScoped<Modules.Application.UseCases.IPedidoUseCase, Modules.Application.UseCases.PedidoUseCase>();

            ConfigSwagger(builder);

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }




            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


        static void ConfigSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "API Fiap", Version = "v1" });
                doc.CustomSchemaIds(x => x.FullName.Replace($"{AppDomain.CurrentDomain.FriendlyName}.", ""));
            });
        }
    }
}