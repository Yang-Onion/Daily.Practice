using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkInfrastructure.Data
{
    public abstract class DataDbContext<IDbContext>:DbContext,IUnitOfWork where IDbContext:DbContext
    {
        private readonly string _connectionString;

        public DataDbContext()
        {
        }

        public DataDbContext(DbContextOptions<IDbContext> options, string connectionString): base(options) {
            _connectionString = connectionString;
        }

        public int Commit()
        {
            return SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return SaveChangesAsync();
        }
    }
}
