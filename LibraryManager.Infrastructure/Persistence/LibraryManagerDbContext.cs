
using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerencimentoBiblioteca.Persistence;

public class LibraryManagerDbContext : DbContext
{
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }
 


    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Configuração para a entidade 'Book'
        builder.Entity<Book>()
            .HasKey(e => e.Id);

        // Configuração para a entidade 'User'
        builder.Entity<User>(e =>
        {
            e.HasKey(e => e.Id);
        });

        // Configuração para a entidade 'BookLoan'
        builder.Entity<BookLoan>(e =>
        {
            e.HasKey(e => e.Id);

            // Relacionamento com a entidade 'Book'
            e.HasOne(bl => bl.Book)
                .WithMany()
                .HasForeignKey(bl => bl.IdBook)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento com a entidade 'User'
            e.HasOne(bl => bl.Client)
                .WithMany()
                .HasForeignKey(bl => bl.IdClient)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

}