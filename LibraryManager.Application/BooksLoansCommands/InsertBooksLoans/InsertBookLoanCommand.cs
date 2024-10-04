using System.ComponentModel.DataAnnotations;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksLoansCommands.InsertBooksLoans;

public class InsertBookLoanCommand : IRequest<ResultViewModel<Guid>>
{
   
    [Required]
    [Display(Name = "ID do Livro")]
    public Guid IdBook { get; set; }

    [Required]
    [Display(Name = "ID do Cliente")]
    public Guid IdClient { get; set; }
    
}