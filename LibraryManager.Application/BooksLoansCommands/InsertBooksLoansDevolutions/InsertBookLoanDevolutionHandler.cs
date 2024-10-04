
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoansDevolutions;

public class InsertBookLoanDevolutionHandler : IRequestHandler<InsertBookLoanDevolutionCommand, ResultViewModel<int>>
{
    private readonly LibraryManagerDbContext _context;

    public InsertBookLoanDevolutionHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertBookLoanDevolutionCommand request, CancellationToken cancellationToken)
    {
        var bookLoan = await _context.BookLoans.FindAsync(request.Id);

        if (bookLoan == null)
        {
            throw new Exception("Empréstimo não encontrado");
        }
        
        bookLoan.SetDevolutionDate(request.Date);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new ResultViewModel<int>(bookLoan.Id);
        
    }
}