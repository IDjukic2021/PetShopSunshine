using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStoreSunshine.Data;

namespace PetStoreSunshine.Data
{
    public class DbClassContext : DbContext
    {
        //internal readonly object User;


        public DbClassContext(DbContextOptions<DbClassContext> options) : base (options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalFood> AnimalFood { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>(e => e.Property(o => o.UserId).hasColumnType("tinyint(1)").HasConversion<short>())
        }
    }
}
