using Microsoft.Data.SqlClient;
using GC.InterfacesFabricas.Fabricas;
using GC.ServicoMapeador.DTO;
namespace GC.ServicoMapeador.Mapeadores;
public class ProdutoMapeador
{
    public static SqlConnection connection = DatabaseFactory.CreateConnection(DatabaseType.SqlServer);

    public static List<Produto> GetProdutos()
    {
        List<Produto> produtos = [];

        connection.Open();

        String sql = "SELECT * FROM Produto";

        using (SqlCommand command = new(sql, connection))
        {
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Produto produto = new(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3));
                produtos.Add(produto);
            }
        }
        connection.Close();
        return produtos;
    }

    public static Produto GetProduto(int codigo)
    {
        connection.Open();

        String sql = "SELECT * FROM Produto WHERE codigo=@codigo";

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@codigo", codigo);

        using SqlDataReader reader = command.ExecuteReader();
        Produto produto = new(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetInt32(3));

        connection.Close();
        return produto;
    }

    public static bool AddProduto(ProdutoDTO produto)
    {
        connection.Open();

        String sql = "INSERT INTO Produto (descricao, valor, estoque) VALUES (@descricao, @valor, @estoque)";

        using SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@descricao", produto.Descricao);
        command.Parameters.AddWithValue("@valor", produto.Valor);
        command.Parameters.AddWithValue("@estoque", produto.Estoque);

        using SqlDataReader reader = command.ExecuteReader();

        connection.Close();
        return true;
    }

    public static bool DeleteProduto(int codigo)
    {
        connection.Open();

        String sql = "DELETE FROM Produto WHERE codigo=@codigo";

        using SqlCommand command = new(sql, connection);

        command.Parameters.AddWithValue("@codigo", codigo);

        using SqlDataReader reader = command.ExecuteReader();

        connection.Close();
        return true;

    }

}