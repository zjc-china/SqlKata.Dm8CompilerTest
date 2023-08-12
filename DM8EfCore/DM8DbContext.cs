using DM8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM8EfCore
{
    public class DM8DbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseDm("Server=127.0.0.1:5236;Database=PERSON;UserId=SYSDBA;Pwd=a1314521@");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集命名空间加载所有的IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
