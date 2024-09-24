using GerencimentoBiblioteca.Entities;
using GerencimentoBiblioteca.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerencimentoBiblioteca.Controllers;

[ApiController]
[Route("api/livros/")]

public class LivrosController : ControllerBase
{
    private readonly LivrosDbContext _contexto;

    // Injeção de depedências
    public LivrosController(LivrosDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var livros = _contexto.Livros;
        return Ok(livros);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        throw new Exception();
        return Ok();
    }

    [HttpPost]
    public IActionResult Post(Livro livro)
    {
        return Ok();
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