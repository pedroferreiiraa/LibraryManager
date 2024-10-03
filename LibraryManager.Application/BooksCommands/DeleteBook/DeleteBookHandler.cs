using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksCommands.DeleteBook;

public class DeleteBookHandler :IRequestHandler<DeleteBookCommand, ResultViewModel<Guid>>
{
    private readonly LibraryManagerDbContext _context;

    public DeleteBookHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<Guid>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (book == null)
        {
            return ResultViewModel<Guid>.Error("Book not found");
        }

        book.SetAsDeleted();
        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);

        
        return ResultViewModel<Guid>.Success(book.Id);
    }

}