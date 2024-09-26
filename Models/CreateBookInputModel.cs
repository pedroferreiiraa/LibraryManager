using GerencimentoBiblioteca.Entities;

namespace GerencimentoBiblioteca.Models;

public class CreateBookInputModel
{
    public CreateBookInputModel(int id, string titulo, string autor, string isbn, int anoDePublicacao)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
        AnoDePublicacao = anoDePublicacao;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Isbn { get; set; }
    public int AnoDePublicacao { get; set; }
    
    public Book ToEntity()
    => new (Id, Titulo, Autor, Isbn, AnoDePublicacao);
}