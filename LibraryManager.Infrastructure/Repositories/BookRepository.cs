using GerencimentoBiblioteca.Persistence;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infraestructure.Repositories;

public class BookRepository : IBookRepository
{
        private readonly LibraryManagerDbContext _context;

        public BookRepository(LibraryManagerDbContext context)
        {
                _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
                var books = await _context.Books.ToListAsync();
                
                return books;
        }

        public async Task<Book> GetById(Guid id)
        {
                return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
                
        }

        public async Task<Guid> Add(Book book)
        {
                await _context.Books.AddAsync(book);
                _context.SaveChanges();
                
                return book.Id;
        }

        public async Task Update(Book book)
        {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
                var book = _context.Books.SingleOrDefault(b => b.Id == id);
                book.SetAsDeleted();
                await _context.SaveChangesAsync();
        }
}