using LabelService.Models;
using Microsoft.EntityFrameworkCore;

namespace LabelService.DatabaseContext
{
    public class  DataContext : DbContext
    {
        public DbSet<Label> Labels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}