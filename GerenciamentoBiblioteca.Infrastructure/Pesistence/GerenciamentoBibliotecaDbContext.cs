using GerenciamentoBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence
{
    public class GerenciamentoBibliotecaDbContext : DbContext
    {
        public GerenciamentoBibliotecaDbContext(DbContextOptions<GerenciamentoBibliotecaDbContext> options) : base(options) { }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
