using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GerencimentoBiblioteca.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksLoanController : ControllerBase
{
    private readonly LibraryManagerDbContext _contexto;

    // Injeção de dependência
    public BooksLoanController(LibraryManagerDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var bookloan = _contexto.BookLoans.ToList();
        
        return Ok(bookloan);
    }
    
    [HttpPost]
    public IActionResult CreateBookLoan(CreateBookLoanInputModel model)
    {
        var book = _contexto.Livros.Find(model.IdBook);
        var user = _contexto.Users.Find(model.IdClient);

        if (book == null || user == null)
        {
            return NotFound("Livro ou usuário não encontrados");
        }

        var bookLoan = new BookLoan(user, book);
        _contexto.BookLoans.Add(bookLoan);
        _contexto.SaveChanges();
        
        return CreatedAtAction(nameof(CreateBookLoan), new { id = bookLoan.Id }, bookLoan);
    }

    [HttpPut("{id}/devolution")]
    public IActionResult SetDevolutionDate(Guid id, DateTime date)
    {
        var bookLoan = _contexto.BookLoans.Find(id);
        if (bookLoan == null)
        {
            return NotFound("Empréstimo não encontrado");
        }
        
        bookLoan.SetDevolutionDate(date);
        _contexto.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}/return")]
    public IActionResult ReturnBookLoan(Guid id)
    {
        var bookLoan = _contexto.BookLoans.Find(id);
        if (bookLoan == null)
        {
            return NotFound("Empréstimo não encontrado");
        }
        
        _contexto.BookLoans.Remove(bookLoan);
        _contexto.SaveChanges();
        
        return NoContent();
    }

    [HttpGet("{id}/status")]
    public IActionResult GetBookLoanStatus(Guid id)
    {
        var bookLoan = _contexto.BookLoans.Find(id);
        if (bookLoan == null)
        {
            return NotFound("Empréstimo não encontrado");
        }
        
        var daysLate = (DateTime.Now - bookLoan.Devolution).Days;
        if (daysLate > 0)
        {
            return Ok($"O livro está {daysLate} dias atrasado.");
        }
        else
        {
            return Ok("O livro está em dia.");
        }
        
    }
    
    
    
}