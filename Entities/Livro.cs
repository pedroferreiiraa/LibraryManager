namespace GerencimentoBiblioteca.Entities;

public class Livro
{
    public Livro(int id, string titulo, string autor, string isbn, int anoDePublicacao)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        ISBN = isbn;
        AnoDePublicacao = anoDePublicacao;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public int AnoDePublicacao { get; set; }
}