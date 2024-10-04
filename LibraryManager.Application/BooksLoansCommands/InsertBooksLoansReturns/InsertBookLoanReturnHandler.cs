using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoansReturns;

public class InsertBookLoanReturnHandler : IRequestHandler<InsertBookLoanReturnCommand, ResultViewModel<int>>
{
    
    private readonly LibraryManagerDbContext _context;
    
    public InsertBookLoanReturnHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertBookLoanReturnCommand request, CancellationToken cancellationToken)
    {
        var bookLoan = await _context.BookLoans.FindAsync(request.Id, cancellationToken);
        if (bookLoan == null)
        {
            throw new ("Empréstimo não encontrado");
        }

        _context.BookLoans.Remove(bookLoan);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(bookLoan.Id);
    }
}