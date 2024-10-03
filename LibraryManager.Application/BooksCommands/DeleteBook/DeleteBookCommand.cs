using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksCommands.DeleteBook;

public class DeleteBookCommand : IRequest<ResultViewModel<Guid>>
{
    public Guid Id { get; set; }
}