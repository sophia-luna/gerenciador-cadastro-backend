namespace GC.ServicoMapeador.DTO;
public class ClienteDTO
{
    public string Contato { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }

    public ClienteDTO()
    {
        Contato = "";
        Email = "";
        Nome = "";
    }
    public ClienteDTO(string contato, string email, string nome)
    {
        Contato = contato;
        Email = email;
        Nome = nome;
    }
}
