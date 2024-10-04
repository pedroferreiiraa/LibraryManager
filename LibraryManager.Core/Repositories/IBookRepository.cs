using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book> GetById(Guid id);
    
    Task<Guid> Add(Book book);
    Task Update(Book book);
    Task Delete(Guid id);
}