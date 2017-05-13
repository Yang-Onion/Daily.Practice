using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Migration.Demo.Model;

namespace WebApi.Migration.Demo
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions options) : base(options){
            Database.Migrate();
        }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Lodging> Lodging { get; set; }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonPhoto> PersonPhoto { get; set; }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<ActivityTripMap> ActivityTripMap { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //多对多
            modelBuilder.Entity<ActivityTripMap>().HasKey(g => new { g.ActivityId, g.TripId });
            modelBuilder.Entity<ActivityTripMap>().HasOne(t => t.Activity).WithMany(t => t.ActivityTripMaps).HasForeignKey(t => t.ActivityId);
            modelBuilder.Entity<ActivityTripMap>().HasOne(t => t.Trip).WithMany(t => t.ActivityTripMaps).HasForeignKey(t => t.TripId);
        }
    }
}
