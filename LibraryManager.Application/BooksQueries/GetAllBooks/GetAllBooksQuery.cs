using GerencimentoBiblioteca.Models;
using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.BooksQueries.GetAllBooks;

public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
{
    
}