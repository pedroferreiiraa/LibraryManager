using GerencimentoBiblioteca.Entities;
using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerencimentoBiblioteca.Controllers;

[ApiController]
[Route("api/user/")]

public class UserController : ControllerBase
{
    private readonly LibraryManagerDbContext _context;

    // Injeção de depedências
    public UserController(LibraryManagerDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users
            .SingleOrDefault(u => u.Id == id);
        
        if (user is null)
        {
            return NotFound();
        }

        var model = UserViewModel.FromEntity(user);

        return Ok(model);

    }
    
    
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var user = new User(model.Id, model.Nome, model.Email);
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        
        return NoContent();
    }
}