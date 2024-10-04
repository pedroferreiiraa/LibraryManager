using GerencimentoBiblioteca.Models;
using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.BooksLoansCommands.InsertBooksLoans;
using LibraryManager.Application.BooksLoansCommands.InsertBooksLoansDevolutions;
using LibraryManager.Application.BooksLoansCommands.InsertBooksLoansReturns;
using LibraryManager.Application.BooksLoansQueries.GetAllBooksLoans;
using LibraryManager.Application.BooksLoansQueries.GetAllBooksLoansStatus;
using LibraryManager.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GerencimentoBiblioteca.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksLoanController : ControllerBase
{
    private readonly LibraryManagerDbContext _contexto;
    private readonly IMediator _mediator;

    // Injeção de dependência
    public BooksLoanController(LibraryManagerDbContext contexto , IMediator mediator)
    {
        _contexto = contexto;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllBooksLoansQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
[HttpPost]
public async Task<IActionResult> CreateBookLoan(InsertBookLoanCommand command)
{
    try
    {
        var bookLoanId = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateBookLoan), new { id = bookLoanId }, null);
    }
    catch (Exception ex)
    {
        return NotFound(ex.Message);
    }
}

    [HttpPut("{id}/devolution")]
    public async Task<IActionResult> SetDevolutionDate(InsertBookLoanDevolutionCommand command)
    {
        var result  = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}/return")]
    public async Task<IActionResult> ReturnBookLoan(InsertBookLoanReturnCommand command)
    {
      var result  = await _mediator.Send(command);
      return Ok(result);
    }

    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetBookLoanStatus()
    {
        var query = new GetAllBooksLoansQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);

    }
    
    
    
}