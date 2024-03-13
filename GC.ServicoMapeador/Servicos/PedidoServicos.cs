using GC.ServicoMapeador.DTO;
using GC.ServicoMapeador.Mapeadores;

namespace GC.ServicoMapeador.Servicos;
public class PedidoServicos
{
    public static List<Pedido> GetPedidos()
    {
        List<PedidoDTO> pedidosIncompleto = PedidoMapeador.GetPedidos();
        List<Pedido> pedidos = [];

        foreach(PedidoDTO pedidoIncompleto in pedidosIncompleto)
        {
            Cliente cliente = ClienteServicos.GetClienteById(pedidoIncompleto.CodigoCliente);
            List<Produto> produtos = PedidoMapeador.FindProdutos(pedidoIncompleto.Codigo);
            Pedido pedido = new(pedidoIncompleto.Codigo, pedidoIncompleto.EnviarPorEmail, cliente, produtos);

            pedidos.Add(pedido);
        } 

        return pedidos;
    }

    public static bool AddPedido(PedidoDTO pedido) 
    {
        return PedidoMapeador.AddPedido(pedido);
    }

    public static bool DeletePedido(int codigo)
    {
        return PedidoMapeador.DeletePedido(codigo);
    }
}

