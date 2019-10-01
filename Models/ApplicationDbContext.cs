using System;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Models
{
    public class ApplicationDbContext: DbContext
    {
       public DbSet<Customer>  Customer { get; set; }
       
       public DbSet<Movie>  Movie { get; set; }

       public DbSet<Genre>  Genre { get; set; }


       public DbSet<MembershipType>  MembershipType { get; set; }




       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
       
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
       }

    }
}
    


