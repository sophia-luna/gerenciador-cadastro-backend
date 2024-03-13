namespace GC.WebAPI.Models;
public class Pedido
{
    public int Codigo { get; set; }
    public bool EnviarPorEmail { get; set; }
    public Cliente Cliente { get; set; }
    public List<Produto> Produtos { get; set; }

    public Pedido(int codigo, bool enviarPorEmail)
    {
        Codigo = codigo;
        EnviarPorEmail = enviarPorEmail;
        Cliente = new();
        Produtos = [];
    }
    public Pedido(int codigo, bool enviarPorEmail, Cliente cliente, List<Produto> produtos)
    {
        Codigo = codigo;
        EnviarPorEmail = enviarPorEmail;
        Cliente = cliente;
        Produtos = produtos;
    }
}
