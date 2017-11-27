using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreHiLoDemo
{
    public class AppDbContext:DbContext
    {

        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Category> Categroys { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "EntityFrameworkCoreHiLoDB",
                UserID = "sa",
                Password = "***"
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //所有实体共用一个Sequence
            //modelBuilder.ForSqlServerUseSequenceHiLo("HiLoSequence");

            //每一个实体分别设置一个Sequence
            //设置Category_HiLoSequence从1000开始
            modelBuilder.HasSequence<int>("Category_HiLoSequence").StartsAt(1000).IncrementsBy(10);
            modelBuilder.Entity<Category>().Property(g => g.Id).ForSqlServerUseSequenceHiLo("Category_HiLoSequence");

            modelBuilder.Entity<Product>().Property(g => g.Id).ForSqlServerUseSequenceHiLo("Product_HiLoSequence");
           
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
