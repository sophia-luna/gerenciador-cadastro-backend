using GC.ServicoMapeador.DTO;
using GC.ServicoMapeador.Servicos;
using Microsoft.AspNetCore.Mvc;

[Route("api/controller")]
[ApiController]
public class PedidoController : ControllerBase
{
    [HttpGet]
    [Route("GetPedido")]
    public List<Pedido> GetPedidos()
    {
        List<Pedido> pedidos = [];
        pedidos = PedidoServicos.GetPedidos();
        return pedidos;
    }

    [HttpPost]
    [Route("PostPedido")]
    public string PostPedido([FromForm] Boolean enviarPorEmail, int codigoCliente)
    {
        PedidoDTO pedido = new(enviarPorEmail, codigoCliente);
        if(PedidoServicos.AddPedido(pedido))
        {
            return "Pedido adicionado com sucesso.";
        }
        return "Erro ao adicionar pedido.";
    }

    [HttpDelete]
    [Route("DeletePedido")]
    public string DeletePedido([FromForm] int codigo)
    {
        if(PedidoServicos.DeletePedido(codigo))
        {
            return "Pedido deletado com sucesso.";
        }
        return "Erro ao deletar pedido.";
    }
}