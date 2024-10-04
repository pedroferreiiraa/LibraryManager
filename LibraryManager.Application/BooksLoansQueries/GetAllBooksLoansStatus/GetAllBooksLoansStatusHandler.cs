using GerencimentoBiblioteca.Persistence;
using LibraryManager.Application.BooksLoansQueries.GetAllBooksLoans;
using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.BooksLoansQueries.GetAllBooksLoansStatus;

    public class GetAllBooksLoansStatusHandler :IRequestHandler<GetAllBooksLoansStatusQuery, ResultViewModel<string>>
{
    
    private readonly LibraryManagerDbContext _context;
    

    public async Task<ResultViewModel<string>> Handle(GetAllBooksLoansStatusQuery request, CancellationToken cancellationToken)
    {
        var bookLoan = await _context.BookLoans.FindAsync(new object[] { request.Id }, cancellationToken);

        if (bookLoan == null)
        {
            // Retorna uma mensagem de erro se o empréstimo não for encontrado
            return ResultViewModel<string>.Error("Empréstimo não encontrado");
        }

        // Calcula o número de dias de atraso
        var daysLate = (DateTime.Now - bookLoan.Devolution).Days;
        string statusMessage = daysLate > 0 
            ? $"O livro está {daysLate} dias atrasado."
            : "O livro está em dia.";

        // Retorna uma mensagem de sucesso com o status do empréstimo
        return ResultViewModel<string>.Success(statusMessage);
    }
}

    