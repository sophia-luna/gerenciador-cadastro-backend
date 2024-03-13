using GC.ServicoMapeador.DTO;
using GC.ServicoMapeador.Mapeadores;

namespace GC.ServicoMapeador.Servicos;
public class ClienteServicos
{
    public static List<Cliente> GetClientes()
    {
        return ClienteMapeador.GetClientes();
    }
    public static Cliente GetClienteById(int codigo)
    {
        return ClienteMapeador.GetClienteById(codigo);
    }
    public static bool AddCliente(ClienteDTO cliente)
    {
        return ClienteMapeador.AddCliente(cliente);
    }
    public static bool DeleteCliente(int codigo)
    {
        return ClienteMapeador.DeleteCliente (codigo);
    }
}
