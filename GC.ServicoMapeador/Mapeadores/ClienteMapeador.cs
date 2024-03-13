using Microsoft.Data.SqlClient;
using GC.InterfacesFabricas.Fabricas;
using GC.ServicoMapeador.DTO;

namespace GC.ServicoMapeador.Mapeadores;
public class ClienteMapeador
{
    public static SqlConnection connection = DatabaseFactory.CreateConnection(DatabaseType.SqlServer);
    public static List<Cliente> GetClientes()
    {
        List<Cliente> clientes = [];

        connection.Open();

        String sql = "SELECT * FROM Cliente";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Cliente cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                clientes.Add(cliente);
            }
        }
        connection.Close();
        return clientes;
    }

    public static Cliente GetClienteById(int codigo)
    {
        Cliente cliente = new();

        connection.Open();

        String sql = "SELECT * FROM Cliente WHERE codigo=@codigo";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@codigo", codigo);
            
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
        }
        connection.Close();
        return cliente;

    }

    public static bool AddCliente(ClienteDTO cliente)
    {
        connection.Open();

        String sql = "INSERT INTO Cliente (nome, email, contato) VALUES (@nome, @email, @contato)";

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@nome", cliente.Nome);
        command.Parameters.AddWithValue("@email", cliente.Email);
        command.Parameters.AddWithValue("@contato", cliente.Contato);

        using SqlDataReader reader = command.ExecuteReader();
        
        connection.Close();
        return true;

    }

    public static bool DeleteCliente(int codigo)
    {
        connection.Open();

        String sql = "DELETE FROM Cliente WHERE Codigo=@codigo";

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@codigo", codigo);

        using SqlDataReader reader = command.ExecuteReader();

        connection.Close();
        return true;

    }
}

