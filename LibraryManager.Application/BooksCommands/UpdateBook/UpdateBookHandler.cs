using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksCommands.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{
    private readonly LibraryManagerDbContext _context;

    // Injeção de dependência
    public UpdateBookHandler(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == request.IdBook);

        if (book is null)
        {
            return ResultViewModel<Guid>.Error("Book not found");
        }    
        
        book.Update(request.Title, request.Author, request.Isbn, request.PublicationYear);
        
        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel<Guid>.Success(book.Id);
    }
}