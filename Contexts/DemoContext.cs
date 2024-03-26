using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Net2024_DemoEntity.Configurations;
using TF_Net2024_DemoEntity.Entities;

namespace TF_Net2024_DemoEntity.Contexts
{
    public class DemoContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<HomeAddress> HomeAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoEFCore;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new HomeAddressConfiguration());
        }
    }
}
