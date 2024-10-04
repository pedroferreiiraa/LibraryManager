using GerencimentoBiblioteca.Persistence;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infraestructure.Repositories;

public class BookLoanRepository : IBookLoanRepository
{
    private readonly LibraryManagerDbContext _context;

    public BookLoanRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(BookLoan bookLoan)
    {
        await _context.BookLoans.AddAsync(bookLoan);
        await _context.SaveChangesAsync();
        return bookLoan.IdBook; // Certifique-se de que seu modelo BookLoan tem uma propriedade Id
    }

    public async Task<BookLoan> GetByIdAsync(Guid id)
    {
        return await _context.BookLoans.FindAsync(id);
    }

    public async Task<List<BookLoan>> GetAllAsync()
    {
        return await _context.BookLoans.ToListAsync();
    }

    public async Task UpdateAsync(BookLoan bookLoan)
    {
        _context.BookLoans.Update(bookLoan);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var bookLoan = await GetByIdAsync(id);
        if (bookLoan != null)
        {
            _context.BookLoans.Remove(bookLoan);
            await _context.SaveChangesAsync();
        }
    }
}