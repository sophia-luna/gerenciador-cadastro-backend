namespace GC.ServicoMapeador.DTO;
public class PedidoDTO
{
    public int Codigo { get; set; }
    public bool EnviarPorEmail { get; set; }
    public int CodigoCliente { get; set; }

    public PedidoDTO(bool enviarPorEmail, int codigoCliente)
    {
        EnviarPorEmail = enviarPorEmail;
        CodigoCliente = codigoCliente;
    }
    public PedidoDTO(int codigo, bool enviarPorEmail, int codigoCliente)
    {
        Codigo = codigo;
        EnviarPorEmail = enviarPorEmail;
        CodigoCliente = codigoCliente;
    }
}
