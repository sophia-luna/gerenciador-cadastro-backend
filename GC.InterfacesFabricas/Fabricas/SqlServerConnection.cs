using Microsoft.Data.SqlClient;
namespace GC.InterfacesFabricas.Fabricas;
public class SqlServerConnection : IDatabaseConnection
{
    private string connectionString;

    public SqlServerConnection()
    {
        connectionString = "Server=tcp:servidor-gerenciador.database.windows.net,1433;Initial Catalog=gerenciadorPedidos;Persist Security Info=False;User ID=gerenciadoradmin;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(this.connectionString);
    }

}