
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Models;

namespace WebApi.Infrastructure
{
    public class ApplicationContext : DbContext
    {
 
        public ApplicationContext(DbContextOptions options) : base(options) {
           
        }

        public DbSet<Student> Student { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=WebApi.Migration.Demo.Lib;User Id=sa;Password=cmsWL2016...;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}