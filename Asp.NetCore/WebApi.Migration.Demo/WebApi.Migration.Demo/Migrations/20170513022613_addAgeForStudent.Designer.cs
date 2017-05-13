using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Migration.Demo;

namespace WebApi.Migration.Demo.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20170513022613_addAgeForStudent")]
    partial class addAgeForStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("DestinationId");

                    b.Property<bool>("IsResort");

                    b.Property<decimal>("MilesFromNearestAirport");

                    b.Property<string>("Name");

                    b.Property<string>("Owner");

                    b.HasKey("LodgingId");

                    b.HasIndex("DestinationId");

                    b.ToTable("Lodging");
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

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Course", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Student")
                        .WithMany("Course")
                        .HasForeignKey("StudentStuId");
                });

            modelBuilder.Entity("WebApi.Migration.Demo.Model.Lodging", b =>
                {
                    b.HasOne("WebApi.Migration.Demo.Model.Destination")
                        .WithMany("Lodgings")
                        .HasForeignKey("DestinationId");
                });
        }
    }
}
