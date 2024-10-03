using GerencimentoBiblioteca.Persistence;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Infraestructure.Repositories;

public class BookRepository : IBookRepository
{
        private readonly LibraryManagerDbContext _context;

        public BookRepository(LibraryManagerDbContext context)
        {
                _context = context;
        }

        public async Task<Guid> Add(Book book)
        {
                await _context.Books.AddAsync(book);
                _context.SaveChanges();
                
                return book.Id;
        }
}