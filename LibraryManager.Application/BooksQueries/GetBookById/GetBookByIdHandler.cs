using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.BooksQueries.GetAllBooks;
using LibraryManager.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksQueries.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
{
    private readonly LibraryManagerDbContext _context;

    public GetBookByIdHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .SingleOrDefaultAsync(b => b.Id == request.Id);

        if (book is null)
        {
            return ResultViewModel<BookViewModel>.Error("Book Not Found");
        }
        
        var model = BookViewModel.FromEntity(book);
        
        return ResultViewModel<BookViewModel>.Success(model);
    }
}