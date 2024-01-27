using Invoices.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Data
{
    public class InvoicesContext : DbContext
    {
        public InvoicesContext()
        {
        }

        public InvoicesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClient> ProductsClients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
         .Entity<ProductClient>()
             .HasKey(pc => new { pc.ClientId, pc.ProductId });

            modelBuilder.Entity<ProductClient>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(pc => pc.ProductId);
            modelBuilder.Entity<ProductClient>()
                .HasOne(pc => pc.Client)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(pc => pc.ClientId);
        }
    }
}
