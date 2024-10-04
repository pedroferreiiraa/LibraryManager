using GerencimentoBiblioteca.Persistence;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infraestructure.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly LibraryManagerDbContext _context;

    public UserRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetAll()
    {
        var user = await _context.Users.ToListAsync();

        if (user == null)
        {
            throw new NotImplementedException();
        }
        
        return user;
    }

    public async Task<User> GetById(Guid id)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            throw new NotImplementedException();    
        }

        return user;
    }

    public async Task<User> Add(User user)
    { 
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}