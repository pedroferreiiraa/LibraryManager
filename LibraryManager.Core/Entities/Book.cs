namespace LibraryManager.Core.Entities;

public class Book
{
    public Book() {}
    
    public Book( string title, string author, string isbn, int publicationYear)
        : base()
    {

        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
    
    public Guid Id { get; set; } = Guid.NewGuid(); // Gera um novo Guid automaticamente

    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    
    public void Update(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
}