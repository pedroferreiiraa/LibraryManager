namespace GerencimentoBiblioteca.Models;

public class CreateBookLoanInputModel
{
    public Guid IdClient { get; set; }
    public Guid IdBook { get; set; }
}
