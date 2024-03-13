using Microsoft.Data.SqlClient;
namespace GC.InterfacesFabricas.Fabricas;

 public static class DatabaseFactory 
    {
        public static SqlConnection CreateConnection(DatabaseType type)
        {
            switch (type)
            {
                default:
                    IDatabaseConnection conexaoBD = new SqlServerConnection();
                    return conexaoBD.GetConnection();
            }
        }
    }