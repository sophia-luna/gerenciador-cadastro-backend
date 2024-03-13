namespace GC.ServicoMapeador.DTO;
public class ProdutoDTO
{
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public int Estoque { get; set; }

    public ProdutoDTO(string descricao, double valor, int estoque)
    {
        Descricao = descricao;
        Valor = valor;
        Estoque = estoque;
    }
}
