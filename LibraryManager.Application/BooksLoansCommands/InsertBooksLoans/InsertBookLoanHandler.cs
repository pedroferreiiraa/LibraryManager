using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoans;

public class InsertBookLoanHandler : IRequestHandler<InsertBookLoanCommand, ResultViewModel<Guid>>
{
    private readonly LibraryManagerDbContext _context;

    public InsertBookLoanHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<Guid>> Handle(InsertBookLoanCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FindAsync(request.IdBook);
        var user = await _context.Users.FindAsync(request.IdClient);

        if (book == null || user == null)
        {
            throw new ("Livro ou usuário não encontrados.");
        }

        var bookLoan = new BookLoan(user, book);
        _context.BookLoans.Add(bookLoan);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<Guid>.Success(bookLoan.IdBook);
    }

    
}