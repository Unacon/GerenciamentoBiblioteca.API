using GerenciamentoBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrastructure.Pesistence.Configuration
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Emprestimo> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Emprestimos)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.IdLivro)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
