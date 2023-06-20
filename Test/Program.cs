using System.Reflection;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FIAP.Adapters.PostgreSQL.Settings.PostgreSQLConnectionString = "User ID=postgres;Password=admin;Host=192.168.1.4;Port=5432;Database=Fiap;";
            TestProduto();
            TestCliente();
            TestPedido();
        }

        static void TestProduto()
        {
            InsertProduct();
            ListProduct();
            ListProductCategory();
            UpdateProduct();
            GetProduct();
        }

        static void TestCliente()
        {
            InsertCliente();
            ListCliente();
            UpdateCliente();
            GetCliente();
            GetCliente("01251305032");
        }

        static void TestPedido()
        {
            InsertPedido();
            ListarPedidos();
        }




        static void InsertProduct()
        {
            FIAP.Modules.Domain.Entities.Produto prod = new FIAP.Modules.Domain.Entities.Produto()
            {
                Nome = $"Teste {Guid.NewGuid().ToString()}",
                Preco = 10,
                ProdutoCategoriaId = FIAP.Modules.Domain.Enums.ProdutoCategoria.Lanche
            };

            Console.WriteLine("Novo produto criado");
            new FIAP.Adapters.PostgreSQL.Repositories.Produto().Insert(prod);
        }

        static void UpdateProduct()
        {
            FIAP.Modules.Domain.Entities.Produto prod = new FIAP.Modules.Domain.Entities.Produto()
            {
                Id = 1,
                Nome = "Teste Update",
                Preco = 10,
                ProdutoCategoriaId = FIAP.Modules.Domain.Enums.ProdutoCategoria.Lanche
            };
            Console.WriteLine("Alteraçao do produto efetuada");
            new FIAP.Adapters.PostgreSQL.Repositories.Produto().Update(prod);
        }

        static void ListProduct()
        {
            var prods = new FIAP.Adapters.PostgreSQL.Repositories.Produto().List();
            Console.WriteLine("Listando produtos");
            prods.ToList().ForEach(prod =>
            {
                Console.WriteLine(prod.Nome);
            });
        }

        static void ListProductCategory()
        {
            var prods = new FIAP.Adapters.PostgreSQL.Repositories.Produto().ListByCategory( FIAP.Modules.Domain.Enums.ProdutoCategoria.Lanche);
            Console.WriteLine("Listando produtos da categoria lanche");
            prods.ToList().ForEach(prod =>
            {
                Console.WriteLine(prod.Nome);
            });
        }

        static void GetProduct()
        {
            var prod = new FIAP.Adapters.PostgreSQL.Repositories.Produto().Get(1);
            Console.WriteLine("Listando produto alterado");
            Console.WriteLine(prod.Nome);
        }



        static void InsertCliente()
        {
            FIAP.Modules.Domain.Entities.Cliente cli = new FIAP.Modules.Domain.Entities.Cliente()
            {
                Nome = $"Teste cliente {Guid.NewGuid().ToString()}",
                Email = $"{Guid.NewGuid().ToString()}@gmail.com",
                Cpf = $"{Guid.NewGuid().ToString()}"
            };

            Console.WriteLine("Novo Cliente criado");
            new FIAP.Adapters.PostgreSQL.Repositories.Cliente().Insert(cli);
        }

        static void UpdateCliente()
        {
            FIAP.Modules.Domain.Entities.Cliente cli = new FIAP.Modules.Domain.Entities.Cliente()
            {
                Id = 1,
                Nome = $"Teste cliente {Guid.NewGuid().ToString()} alterado",
                Email = $"{Guid.NewGuid().ToString()}@gmail.com",
                Cpf = $"01251305032"
            };
            Console.WriteLine("Alteraçao do produto efetuada");
            new FIAP.Adapters.PostgreSQL.Repositories.Cliente().Update(cli);
        }

        static void ListCliente()
        {
            var clientes = new FIAP.Adapters.PostgreSQL.Repositories.Cliente().List();
            Console.WriteLine("Listando Clientes");
            clientes.ToList().ForEach(cli =>
            {
                Console.WriteLine(cli.Nome);
            });
        }

        static void GetCliente()
        {
            var cli = new FIAP.Adapters.PostgreSQL.Repositories.Cliente().Get(1);
            Console.WriteLine("Listando cliente alterado");
            Console.WriteLine(cli.Nome);
        }

        static void GetCliente(string cpf)
        {
            var cli = new FIAP.Adapters.PostgreSQL.Repositories.Cliente().GetByCpf(cpf);
            Console.WriteLine("Listando pelo cpf");
            Console.WriteLine(cli.Nome);
        }

        static void InsertPedido()
        {
            FIAP.Modules.Domain.Entities.Pedido ped = new FIAP.Modules.Domain.Entities.Pedido()
            {
                Anonimo = false,
                ClienteId = 1,
                ClienteObservacao = "teste obs",
                PedidoStatusId = FIAP.Modules.Domain.Enums.PedidoStatus.Recebido,
                Valor = 20,
                Itens = new List<FIAP.Modules.Domain.Entities.PedidoItem>
                      {
                        new FIAP.Modules.Domain.Entities.PedidoItem
                        {
                              ProdutoId = 1,
                              PrecoUnitario = 10,
                              Quantidade = 2
                        }
                      }
            };

            Console.WriteLine("Novo pedido criado");
            new FIAP.Adapters.PostgreSQL.Repositories.Pedido().Order(ped);
        }

        static void ListarPedidos()
        {
            var pedidos = new FIAP.Adapters.PostgreSQL.Repositories.Pedido().List();
            Console.WriteLine("Listando pedidos");
            pedidos.ToList().ForEach(ped =>
            {
            Console.WriteLine($"iD:{ped.Id} - Data:{ped.Data}");
            });
        }
    }
}