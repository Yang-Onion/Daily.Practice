using Microsoft.EntityFrameworkCore;
using System;
using UnitOfWorkModel;

namespace UnitOfWorkInfrastructure.Data
{
    public interface IDemoUnit : IUnitOfWork{}
    public class UnitDbContext:DataDbContext<UnitDbContext>, IDemoUnit
    {

        public UnitDbContext(DbContextOptions<UnitDbContext> options, IConfiguration config)
            : base(options, config.GetConnectionString("UnitDbContextConnection")) {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourseMaps> StudentCourseMapse { get; set; } 

    }
}
