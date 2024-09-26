using GerencimentoBiblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerencimentoBiblioteca.Persistence;

public class LibraryManagerDbContext : DbContext
{
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<Book> Livros { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>()
            .HasKey(e => e.Id);

        builder
            .Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
            });
    }
}