using Microsoft.EntityFrameworkCore;
using Servidor.Domain.Entities;

namespace Servidor.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Status> Status => Set<Status>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("Task");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Titulo)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Descricao)
                      .HasMaxLength(255);

                entity.Property(e => e.DataDeCriacao)
                      .HasDefaultValueSql("getdate()");

                entity.HasOne(e => e.Status)
                      .WithMany()
                      .HasForeignKey(e => e.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Descricao)
                      .IsRequired()
                      .HasMaxLength(255);
            });
        }
    }
}
