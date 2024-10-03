using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksQueries.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, ResultViewModel<List<BookViewModel>>>
{
    private readonly LibraryManagerDbContext _context;

    public GetAllBooksHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<List<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .Where(b => !b.IsDeleted).ToListAsync();
    
        var model = book.Select(BookViewModel.FromEntity).ToList();
    
        return ResultViewModel<List<BookViewModel>>.Success(model);
    }
}