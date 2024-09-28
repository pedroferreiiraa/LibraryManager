using GerencimentoBiblioteca.Entities;
using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerencimentoBiblioteca.Controllers;

[ApiController]
[Route("api/livros/")]
public class BooksController : ControllerBase
{
    private readonly LibraryManagerDbContext _contexto;

    // Injeção de dependência
    public BooksController(LibraryManagerDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var livros = _contexto.Livros.ToList();
        var model = livros.Select(l => BookViewModel.FromEntity(l)).ToList();
        return Ok(model);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var livro = _contexto.Livros.SingleOrDefault(l => l.Id == id);
        
        if (livro != null)
        {
            var model = BookViewModel.FromEntity(livro);
            return Ok(model);
        }

        return NotFound(); // Retorna NotFound se o livro não for encontrado
    }

    [HttpPost]
    public IActionResult Post(CreateBookInputModel model)
    {
        var book = model.ToEntity(); // Certifique-se de que o método ToEntity() está gerando um novo Guid para o Id.

        _contexto.Livros.Add(book);
        _contexto.SaveChanges();
        
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, UpdatBookInputModel model)
    {
        var book = _contexto.Livros.SingleOrDefault(l => l.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        
        book.Update(model.Titulo, model.Autor, model.Isbn, model.AnoDePublicacao);
        _contexto.Livros.Update(book);
        _contexto.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var livro = _contexto.Livros.SingleOrDefault(e => e.Id == id);

        if (livro == null)
        {
            return NotFound();
        }
        
        _contexto.Livros.Remove(livro);
        _contexto.SaveChanges();
        
        return NoContent();
    }
}

