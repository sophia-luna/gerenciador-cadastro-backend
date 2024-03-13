public class Cliente
{
    public int Codigo { get; set; }
    public string Contato { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }

    public Cliente()
    {
        Nome = "";
        Contato = "";
        Email = "";

    }
    public Cliente(int codigo, string contato, string email, string nome)
    {
        Codigo = codigo;
        Contato = contato;
        Email = email;
        Nome = nome;
    }
}
