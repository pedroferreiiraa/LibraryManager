using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoansReturns;

public class InsertBookLoanReturnCommand : IRequest<ResultViewModel<int>>
{
    public int Id { get; set; }
}