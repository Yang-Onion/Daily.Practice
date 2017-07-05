using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Common.Enities.Entities.Identity;
using AspNetCore.Common.Enities.Pagination;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AspNetCore.Common.Enities.DbContext
{
    public interface IIdentityDbContext : IUnitOfWork
    {
    }
    public class IdentityDbContext : IdentityDbContext<AppUser>, IIdentityDbContext, IUnitOfWork
    {
        private readonly IConfiguration _config;

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IConfiguration config)
            : base(options) {
            _config = config;
        }
        
        public int Commit() {
            return SaveChanges();
        }

        public Task<int> CommitAsync() {
            return SaveChangesAsync();
        }

        public T ExecuteScalar<T>(string sql) {
            throw new NotImplementedException();
        }

        public DbSet<T> Set<T>() where T : class {
            throw new NotImplementedException();
        }

        public PagedList<T> Sql<T>(string sql, string orderColumn, PageQuery pager) {
            throw new NotImplementedException();
        }

        public IList<T> Sql<T>(string sql) {
            throw new NotImplementedException();
        }



        public DbSet<Menus> Menus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("IdentityDbConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
    }
}
