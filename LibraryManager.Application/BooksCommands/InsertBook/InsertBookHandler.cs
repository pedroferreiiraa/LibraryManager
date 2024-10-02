using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;

using MediatR;

namespace LibraryManager.Application.BooksCommands.InsertBook;

public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<Guid>>
{
    private readonly LibraryManagerDbContext _context;

    // Injeção de dependência
    public InsertBookHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }

    
    
    public async Task<ResultViewModel<Guid>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();
        
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
        return ResultViewModel<Guid>.Success(book.Id);
    }
}