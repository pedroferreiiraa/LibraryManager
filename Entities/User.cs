namespace GerencimentoBiblioteca.Entities;

public class User
{
    public User(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}