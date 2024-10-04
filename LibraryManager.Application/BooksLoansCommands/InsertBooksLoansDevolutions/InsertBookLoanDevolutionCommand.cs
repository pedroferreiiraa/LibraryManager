using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoansDevolutions;

public class InsertBookLoanDevolutionCommand : IRequest<ResultViewModel<int>>
{
    
    public int Id { get; set; }
    
    public DateTime Date { get; set; }
}