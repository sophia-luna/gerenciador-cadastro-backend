using Microsoft.Data.SqlClient;
using GC.InterfacesFabricas.Fabricas;
using GC.ServicoMapeador.DTO;

namespace GC.ServicoMapeador.Mapeadores;

public class PedidoMapeador
{
    private static SqlConnection connection = DatabaseFactory.CreateConnection(DatabaseType.SqlServer);

    public static List<PedidoDTO> GetPedidos()
    {
        List<PedidoDTO> pedidos = [];

        connection.Open();

        String sql = "SELECT * FROM Pedido";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PedidoDTO pedido = new PedidoDTO(reader.GetInt32(0), reader.GetBoolean(1), reader.GetInt32(2));
                pedidos.Add(pedido);
            }
        }
        connection.Close();
        return pedidos;
    }

    public static List<Produto> FindProdutos(int codigoPedido)
    {
        List<Produto> produtos = [];

        connection.Open();

        String sql = "SELECT * FROM Produto WHERE codigo IN (SELECT Produto_codigo FROM PEDIDO_PRODUTO WHERE pedido_codigo=@codigoPedido);";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {

            command.Parameters.AddWithValue("@codigoPedido", codigoPedido);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto produto = new Produto(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3));
                    produtos.Add(produto);
                }
            }
        }
        connection.Close();
        return produtos;
    }

    public static bool AddPedido(PedidoDTO pedido)
    {
        connection.Open();

        String sql = "INSERT INTO Pedido (enviar_por_email, cliente_codigo) VALUES (@enviarPorEmail, @codigoCliente)";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {

            command.Parameters.AddWithValue("@enviarPorEmail", pedido.EnviarPorEmail);
            command.Parameters.AddWithValue("@codigoCliente", pedido.CodigoCliente);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                connection.Close();
                return true;
            }
        }

    }

    public static bool DeletePedido(int codigo)
    {
        connection.Open();

        String sql = "DELETE FROM Pedido WHERE Codigo=@codigo";

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@codigo", codigo);

        using SqlDataReader reader = command.ExecuteReader();
        
        connection.Close();
        return true;

    }
}