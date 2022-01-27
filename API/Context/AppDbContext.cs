using API.EntityConfig;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collaborator>(new CollaboratorConfig().Configure);
            modelBuilder.Entity<Address>(new AddressConfig().Configure);
        }
    }
}