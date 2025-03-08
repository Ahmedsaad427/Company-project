using Company.G02.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Company.G02.DAL.Data.Contexts
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Server=Ahmed;Database=CompanyG02;Trusted_Connection=True;TrustServerCertificate=True"
        //    );
        //}
        public DbSet<Department>Departments { get; set; }
    }
}
