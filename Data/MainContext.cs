using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    internal class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(50);
            modelBuilder.Entity<Todo>().Property(t => t.Name).HasMaxLength(50);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<Todo>().Where(e => e.State == EntityState.Added))
            {
                entry.Property(e => e.Registered).CurrentValue = DateTime.Now;
            }

            return await base.SaveChangesAsync();
        }
    }
}
