using Microsoft.AspNetCore.Mvc;
using GC.ServicoMapeador.Servicos;
using GC.ServicoMapeador.DTO;


[Route("api/controller")]
[ApiController]
public class ProdutoController : ControllerBase
{
    [HttpGet]
    [Route("GetProduto")]
    public List<Produto> GetProdutos()
    {
        List<Produto> produtos = new();
        produtos = ProdutoServico.GetProdutos();
        return produtos;
    }

    [HttpPost]
    [Route("PostProduto")]
    public string PostProduto([FromForm] string descricao, double valor, int estoque)
    {
        ProdutoDTO produto = new(descricao, valor, estoque);
        if(ProdutoServico.AddProduto(produto))
        {
            return "Produto adicionado com sucesso.";
        }
        return "Erro ao adicionar produto.";
    }

    [HttpDelete]
    [Route("DeleteProduto")]
    public string DeleteProduto([FromForm] int codigo)
    {
        if(ProdutoServico.DeleteProduto(codigo))
        {
            return "Produto deletado com sucesso.";
        }
        return "Erro ao deletar produto.";
    }

}