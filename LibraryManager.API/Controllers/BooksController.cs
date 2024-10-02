using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.BooksCommands.InsertBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerencimentoBiblioteca.Controllers;

[ApiController]
[Route("api/livros/")]
public class BooksController : ControllerBase
{
    private readonly LibraryManagerDbContext _contexto;
    private readonly IMediator _mediator;

    // Injeção de dependência
    public BooksController(LibraryManagerDbContext contexto, IMediator mediator)
    {
        _contexto = contexto;
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var livros = _contexto.Books.ToList();
        var model = livros.Select(l => BookViewModel.FromEntity(l)).ToList();
        return Ok(model);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var livro = _contexto.Books.SingleOrDefault(l => l.Id == id);
        
        if (livro != null)
        {
            var model = BookViewModel.FromEntity(livro);
            return Ok(model);
        }

        return NotFound(); // Retorna NotFound se o livro não for encontrado
    }

    [HttpPost]
    public async  Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, UpdatBookInputModel model)
    {
        var book = _contexto.Books.SingleOrDefault(l => l.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        
        book.Update(model.Titulo, model.Autor, model.Isbn, model.AnoDePublicacao);
        _contexto.Books.Update(book);
        _contexto.SaveChanges();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var livro = _contexto.Books.SingleOrDefault(e => e.Id == id);

        if (livro == null)
        {
            return NotFound();
        }
        
        _contexto.Books.Remove(livro);
        _contexto.SaveChanges();
        
        return NoContent();
    }
}

