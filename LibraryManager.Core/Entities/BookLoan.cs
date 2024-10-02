namespace LibraryManager.Core.Entities;

public class BookLoan
{
    private BookLoan() { }

    public BookLoan(User client, Book book)
    {
        Client = client;
        Book = book;
    }

    public BookLoan(Guid idClient, Guid idBook, User client, Book book)
    {
        IdClient = idClient;
        IdBook = idBook;
        Client = client;
        Book = book;
    }

    public int Id { get; private set; }
    public Guid IdClient { get; private set; }

    public User? Client { get; private set; }
    
    // Mudei o tipo de IdBook para Guid
    public Guid IdBook { get; private set; }

    public Book? Book { get; private set; }

    public DateTime LoanDate { get; private set; } = DateTime.Now.Date;

    public DateTime Devolution { get; private set; } = DateTime.Now.Date.AddDays(7);

    public void UpdateLoan( Guid idBook, Guid idClient)
    {
        IdClient = idClient;
        IdBook = idBook;
    }

    public void Renewal(DateTime date)
    {
        Devolution = date;
    }
    
    public void SetDevolutionDate(DateTime date)
    {
        Devolution = date;
    }
}