using Microsoft.EntityFrameworkCore;
using UniversityHomework.Models;

namespace UniversityHomework.Context
{
    public class HomeworkContext : DbContext
    {
        public DbSet<Employee> Employees;

        public HomeworkContext()
        {
        }

        public HomeworkContext(DbContextOptions<HomeworkContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Initial Catalog=BookStoreDatabase;Integrated Security=True;Pooling=False");
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
