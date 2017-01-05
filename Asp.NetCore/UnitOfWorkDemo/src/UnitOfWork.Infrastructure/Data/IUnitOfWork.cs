using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace UnitOfWorkInfrastructure.Data
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();

        DbSet<T> Set<T>() where T : class;

    }
}
