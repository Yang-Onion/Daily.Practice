using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore.EF.Model
{
    public class EFCoreContext:DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Publisher> Publisher { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Publisher>().HasKey(g => new {g.Id,g.PubNo});
        }
    }
}
