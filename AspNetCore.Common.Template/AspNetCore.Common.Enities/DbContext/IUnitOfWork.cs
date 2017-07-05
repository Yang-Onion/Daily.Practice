using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Common.Enities.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AspNetCore.Common.Enities.DbContext
{
    public interface IUnitOfWork
    {
        DatabaseFacade Database { get; }

        int Commit();

        Task<int> CommitAsync();

        DbSet<T> Set<T>() where T : class;

        PagedList<T> Sql<T>(string sql, string orderColumn, PageQuery pager);

        IList<T> Sql<T>(string sql);

        T ExecuteScalar<T>(string sql);
    }
}
