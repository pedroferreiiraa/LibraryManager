
using LibraryManager.Core.Entities;

namespace GerencimentoBiblioteca.Models;

public class CreateBookInputModel
{
    

    
    // Remova o campo Id do construtor, pois ele será gerado automaticamente.
    public CreateBookInputModel(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }

    // Remova a propriedade Id, pois será gerada automaticamente no ToEntity()
    // public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    
    public Book ToEntity()
    {
        return new Book
        {
            Id = Guid.NewGuid(), // Gera um novo Guid
            Title = this.Title,
            Author = this.Author,
            Isbn = this.Isbn,
            PublicationYear=  this.PublicationYear
        };
    }
}