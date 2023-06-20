using Npgsql;

namespace FIAP.Adapters.PostgreSQL
{
    /// <summary>
    /// Classe que provê acesso ao bando de dados relacional
    /// </summary>
    public static class Database
    {
        static Database()
        {
            //Marca o dapper pra fazer o match dos nomes com underscores
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public static NpgsqlConnection Connection()
        {
            return new NpgsqlConnection(Settings.PostgreSQLConnectionString);
        }
    }
}
