public class BookLoanViewModel
{
    public Guid Id { get; set; } // Altere para Guid
    public Guid IdClient { get; set; } // Altere para Guid
    public Guid IdBook { get; set; } // Altere para Guid
    public DateTime LoanDate { get; set; }
    public DateTime Devolution { get; set; }

    public static BookLoanViewModel FromEntity(BookLoan bookLoan)
    {
        return new BookLoanViewModel
        {
            Id = bookLoan.Id,
            IdClient = bookLoan.IdClient,
            IdBook = bookLoan.IdBook,
            LoanDate = bookLoan.LoanDate,
            Devolution = bookLoan.Devolution
        };
    }
}