public class Produto
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public int Estoque { get; set; }

    public Produto(int codigo, string descricao, double valor, int estoque)
    {
        Codigo = codigo;
        Descricao = descricao;
        Valor = valor;
        Estoque = estoque;
    }
}
