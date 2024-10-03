using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksCommands.UpdateBook;

public class UpdateBookCommand : IRequest<ResultViewModel>
{
    public Guid IdBook { get; set; }
    public string Title  { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
}