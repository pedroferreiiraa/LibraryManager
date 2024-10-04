using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IBookLoanRepository
{
    Task<Guid> AddAsync(BookLoan bookLoan);
    Task<BookLoan> GetByIdAsync(Guid id);
    Task<List<BookLoan>> GetAllAsync();
    Task UpdateAsync(BookLoan bookLoan);
    Task DeleteAsync(Guid id);
}