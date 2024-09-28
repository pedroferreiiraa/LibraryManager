using BooksManagement.API.Entities;
using GerencimentoBiblioteca.Entities;

namespace GerencimentoBiblioteca.Models;

public class UserViewModel
{
    public UserViewModel( Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; } = Guid.NewGuid(); // Gera um novo Guid automaticamente
    public string Name { get; set; }
    public string Email { get; set; }
    
    
    public static UserViewModel FromEntity(User user) 
    => new UserViewModel(user.Id, user.Name, user.Email);
}