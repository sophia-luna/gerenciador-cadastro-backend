using Microsoft.AspNetCore.Mvc;
using GC.ServicoMapeador.Servicos;
using GC.ServicoMapeador.DTO;

[Route("api/controller")]
[ApiController]
public class ClienteController : ControllerBase
{

    [HttpGet]
    [Route("GetCliente")]
    public List<Cliente> GetClientes()
    {
        List<Cliente> clientes = new();
        clientes = ClienteServicos.GetClientes();
        return clientes;
    }

    [HttpPost]
    [Route("PostCliente")]
    public string PostCliente([FromForm] string nome, string email, string contato)
    {
        ClienteDTO cliente = new ClienteDTO(nome, email, contato);
        if(ClienteServicos.AddCliente(cliente))
        {
            return "Cliente adicionado com sucesso.";
        }
        return "Erro ao adicionar cliente.";
    }

    [HttpDelete]
    [Route("DeleteCliente")]
    public string DeleteCliente([FromForm] int codigo)
    {
        if(ClienteServicos.DeleteCliente(codigo))
        {
            return "Cliente deletado com sucesso.";
        }
        return "Erro ao deletar cliente.";
    }
}


