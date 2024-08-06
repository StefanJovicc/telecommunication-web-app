using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelecommunicationWebApp.Domain;

namespace TelecommunicationWebApp.DataAccess
{
    public class TelecommunicationContext : DbContext
    {
        private readonly string _connectionString;

        public TelecommunicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TelecommunicationContext()
        {
            _connectionString = "Data Source=localhost;Initial Catalog=TelecommunicationWebApp;TrustServerCertificate=true;Integrated security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            // Configuring self-referencing Users (users who have spouses)
            modelBuilder.Entity<User>()
                        .HasOne(u => u.Spouse)
                        .WithMany(u => u.SpouseUsers)
                        .HasForeignKey(u => u.SpouseId)
                        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.ModifiedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<IssuedDiscount> IssuedDiscounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<UserColor> UsersColors { get; set; }
    }
}
