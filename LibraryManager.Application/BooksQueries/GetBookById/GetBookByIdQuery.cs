using GerencimentoBiblioteca.Models;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksQueries.GetBookById;

public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
{
    public GetBookByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}