using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FIAP.Adapters.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Adapters.PostgreSQL.Settings.PostgreSQLConnectionString = Settings.PostgreSQLConnectionString;

            builder.Services.AddScoped<Modules.Domain.Repositories.ICliente, Adapters.PostgreSQL.Repositories.Cliente>();
            builder.Services.AddScoped<Modules.Domain.Repositories.IProduto, Adapters.PostgreSQL.Repositories.Produto>();
            builder.Services.AddScoped<Modules.Domain.Repositories.IPedido, Adapters.PostgreSQL.Repositories.Pedido>();

            builder.Services.AddScoped<Modules.Application.UseCases.IClienteUseCase, Modules.Application.UseCases.ClienteUseCase>();
            builder.Services.AddScoped<Modules.Application.UseCases.IProdutoUseCase, Modules.Application.UseCases.ProdutoUseCase>();
            builder.Services.AddScoped<Modules.Application.UseCases.IPedidoUseCase, Modules.Application.UseCases.PedidoUseCase>();

            builder.Services.AddScoped<Modules.Domain.Services.IPagamentoGateway, Adapters.Payment.MercadoPago>();


            ConfigSwagger(builder);

            var app = builder.Build();
            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

          

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger/");
                    return Task.CompletedTask;
                });

                // outros mapeamentos de endpoints
            });

            app.Run();
        }


        static void ConfigSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "API Fiap", Version = "v1" });
                doc.CustomSchemaIds(x => x.FullName.Replace($"{AppDomain.CurrentDomain.FriendlyName}.", ""));

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);
            });
        }
    }
}