using Microsoft.Data.SqlClient;
namespace GC.InterfacesFabricas.Fabricas;
public interface IDatabaseConnection
{
    SqlConnection GetConnection();
}