using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.BooksCommands.InsertBook;

public class InsertBookCommand :  IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Gera um novo Guid automaticamente

    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    
    public Book ToEntity() 
        => new(Title, Author, Isbn, PublicationYear);
}

