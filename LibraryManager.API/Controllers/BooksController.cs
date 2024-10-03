using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.BooksCommands.DeleteBook;
using LibraryManager.Application.BooksCommands.InsertBook;
using LibraryManager.Application.BooksCommands.UpdateBook;
using LibraryManager.Application.BooksQueries.GetAllBooks;
using LibraryManager.Application.BooksQueries.GetBookById;
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
    public async Task<IActionResult> Get()
    {
        var query = new GetAllBooksQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetBookByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async  Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateBookCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async  Task<IActionResult> Delete(DeleteBookCommand command)
    {
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
}

