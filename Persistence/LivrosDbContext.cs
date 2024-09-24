using GerencimentoBiblioteca.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerencimentoBiblioteca.Persistence;

public class LivrosDbContext : DbContext
{
    public LivrosDbContext(DbContextOptions<LivrosDbContext> options) 
        : base(options)
    {
        
    }
        
    
    public DbSet<Livro> Livros { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livro>()
            .HasKey(e => e.Id);
    }
    
}