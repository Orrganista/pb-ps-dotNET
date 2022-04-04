using EFDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PersonGroup>()
            .HasKey(pg => new { pg.PersonId, pg.GroupId });

            builder.Entity<PersonGroup>()
            .HasOne<Person>(pg => pg.Person) 
            .WithMany(p => p.PersonGroups)
            .HasForeignKey(p => p.PersonId);

            builder.Entity<PersonGroup>()
            .HasOne<Group>(pg => pg.Group) 
            .WithMany(g => g.PersonGroups) 
            .HasForeignKey(g => g.GroupId);
        }

    }
}
