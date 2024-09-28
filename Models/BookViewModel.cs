using GerencimentoBiblioteca.Entities;

namespace GerencimentoBiblioteca.Models;

public class BookViewModel
{
    public BookViewModel(Guid id, string title, string author, string isbn, int publicationYear)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
    
    public Guid Id { get; set; }  // Adicione este campo
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }


    public static BookViewModel FromEntity(Book book)
    => new BookViewModel( book.Id, book.Title, book.Author, book.Isbn, book.PublicationYear);

}