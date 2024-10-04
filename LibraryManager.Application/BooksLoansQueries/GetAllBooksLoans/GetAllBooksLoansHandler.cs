using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksLoansQueries.GetAllBooksLoans;


public class GetAllBooksLoansQueryHandler : IRequestHandler<GetAllBooksLoansQuery, ResultViewModel<List<BookLoanViewModel>>>
{
    private readonly LibraryManagerDbContext _context;

    public GetAllBooksLoansQueryHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<BookLoanViewModel>>> Handle(GetAllBooksLoansQuery request, CancellationToken cancellationToken)
    {
        var bookLoans = await _context.BookLoans.ToListAsync(cancellationToken);

        // Mapeando BookLoan para BookLoanViewModel
        var bookLoanViewModels = bookLoans.Select(bl => new BookLoanViewModel
        {
            Id = bl.Id,
            IdClient = bl.IdClient,
            IdBook = bl.IdBook,
            LoanDate = bl.LoanDate,
            Devolution = bl.Devolution
        }).ToList();

        return ResultViewModel<List<BookLoanViewModel>>.Success(bookLoanViewModels);
    }
}