namespace GerencimentoBiblioteca.Entities;

public class Book
{
    protected Book() {}
    
    public Book(int id, string titulo, string autor, string isbn, int anoDePublicacao)
        : base()
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
    
    public void Update(string titulo, string autor, string isbn, int anoDePublicacao)
    {
        Titulo = titulo;
        Autor = autor;
        Isbn = isbn;
        AnoDePublicacao = anoDePublicacao;
    }
    
}