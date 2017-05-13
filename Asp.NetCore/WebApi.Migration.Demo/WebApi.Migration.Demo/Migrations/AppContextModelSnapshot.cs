using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Migration.Demo;

namespace WebApi.Migration.Demo.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.ActivityTripMap", b =>
                {
                    b.Property<int>("ActivityId");

                    b.Property<int>("TripId");

                    b.HasKey("ActivityId", "TripId");

                    b.HasIndex("TripId");

                    b.ToTable("ActivityTripMap");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Course", b =>
                {
                    b.Property<int>("CoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int?>("StudentStuId");

                    b.HasKey("CoId");

                    b.HasIndex("StudentStuId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Photo");

                    b.HasKey("DestinationId");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Lodging", b =>
                {
                    b.Property<int>("LodgingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DestId");

                    b.Property<bool>("IsResort");

                    b.Property<decimal>("MilesFromNearestAirport");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.Property<int?>("PrimaryContactId");

                    b.Property<int?>("SecondContactId");

                    b.HasKey("LodgingId");

                    b.HasIndex("DestId");

                    b.HasIndex("PrimaryContactId");

                    b.HasIndex("SecondContactId");

                    b.ToTable("Lodging");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.PersonPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<int>("PersonId");

                    b.Property<byte[]>("Photo");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonPhoto");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Student", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("StuName");

                    b.HasKey("StuId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CostUSD");

                    b.Property<DateTime>("EndDate");

                    b.Property<byte[]>("RowVersion");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TripId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.ActivityTripMap", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Activity", "Activity")
                        .WithMany("ActivityTripMaps")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Migration.Demo.Model.Trip", "Trip")
                        .WithMany("ActivityTripMaps")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Course", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Student")
                        .WithMany("Course")
                        .HasForeignKey("StudentStuId");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Lodging", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Destination", "Target")
                        .WithMany("Lodgings")
                        .HasForeignKey("DestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Migration.Demo.Model.Person", "PrimaryContact")
                        .WithMany("PrimaryContactFor")
                        .HasForeignKey("PrimaryContactId");

                    b.HasOne("WebApi.Migration.Demo.Model.Person", "SecondContact")
                        .WithMany("SecondContactFor")
                        .HasForeignKey("SecondContactId");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.PersonPhoto", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Person", "PhotoOf")
                        .WithOne("Photo")
                        .HasForeignKey("WebApi.Migration.Demo.Model.PersonPhoto", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
