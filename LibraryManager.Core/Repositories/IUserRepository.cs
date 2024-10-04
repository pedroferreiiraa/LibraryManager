using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> Add(User user);
}