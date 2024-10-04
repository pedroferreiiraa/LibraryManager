using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansQueries.GetAllBooksLoansStatus;

public class GetAllBooksLoansStatusQuery: IRequest<ResultViewModel<string>>
{
    public int Id { get; }

    public GetAllBooksLoansStatusQuery(int id)
    {
        Id = id;
    }
}