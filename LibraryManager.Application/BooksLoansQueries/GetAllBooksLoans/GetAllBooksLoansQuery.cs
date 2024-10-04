using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.BooksLoansQueries.GetAllBooksLoans;

public class GetAllBooksLoansQuery : IRequest<ResultViewModel<List<BookLoanViewModel>>>, IRequest<ResultViewModel<List<BookLoan>>>
{
    
}