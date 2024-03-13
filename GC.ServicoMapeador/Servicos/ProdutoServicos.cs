using GC.ServicoMapeador.DTO;
using GC.ServicoMapeador.Mapeadores;

namespace GC.ServicoMapeador.Servicos;
public class ProdutoServico
{
    public static List<Produto> GetProdutos()
    {
        return ProdutoMapeador.GetProdutos();
    }

    public static Produto GetProdutoById(int codigo)
    {
        return ProdutoMapeador.GetProduto(codigo);
    }

    public static bool AddProduto(ProdutoDTO produto) 
    {
        return ProdutoMapeador.AddProduto(produto);
    }

    public static bool DeleteProduto(int codigo)
    {
        return ProdutoMapeador.DeleteProduto(codigo);
    }
}

