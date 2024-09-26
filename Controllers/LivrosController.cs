using GerencimentoBiblioteca.Entities;
using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerencimentoBiblioteca.Controllers;

[ApiController]
[Route("api/livros/")]

public class LivrosController : ControllerBase
{
    private readonly LibraryManagerDbContext _contexto;

    // Injeção de depedências
    public LivrosController(LibraryManagerDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var livros = _contexto.Livros.ToList();

        var model = livros.Select(l => BookItemViewModel.FromEntity(l)).ToList();
        return Ok(model);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var livro = _contexto.Livros
            .SingleOrDefault(l => l.Id == id);
        
        if (livro != null)
        {
            var model = BookItemViewModel.FromEntity(livro);
            
            return Ok(model);
        }

        return Ok();
    }

    [HttpPost]
    public IActionResult Post(CreateBookInputModel model)
    {
        var book = model.ToEntity();
        
        _contexto.Livros.Add(book);
        _contexto.SaveChanges();
        
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdatBookInputModel model)
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
    public IActionResult Delete(int id)
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