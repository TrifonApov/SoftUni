<<<<<<< HEAD
﻿using Trucks.Data.Models;

namespace Trucks.Data
=======
﻿namespace Trucks.Data
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
{
    using Microsoft.EntityFrameworkCore;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
<<<<<<< HEAD
        {
        }

        public TrucksContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientTruck> ClientsTrucks { get; set; }
        public DbSet<Despatcher> Despatchers { get; set; }
        public DbSet<Truck> Trucks { get; set; }
=======
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options) 
        { 
        }

>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6

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
<<<<<<< HEAD
            modelBuilder.Entity<ClientTruck>(e =>
                e.HasKey(ct => new { ct.ClientId, ct.TruckId }));
=======
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }
    }
}
