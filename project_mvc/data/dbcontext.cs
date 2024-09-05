using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using task1.Models;

namespace task1.data
{
    public class dbcontext:DbContext
    {
        public DbSet<student> students { set; get; }
        public DbSet<department> departments { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.;Database=mvc1;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<student>()
               .HasIndex(s => s.email)//crerate index in email
               .IsUnique();//check uniqe
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }

    }

