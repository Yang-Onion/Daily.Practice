using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Asp.NetCore.EF.Model;

namespace Asp.NetCore.EF.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    partial class EFCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp.NetCore.EF.Model.Blog", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Asp.NetCore.EF.Model.Publisher", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("PubNo");

                    b.Property<string>("PublishName");

                    b.HasKey("Id", "PubNo");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("Asp.NetCore.EF.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleTyp");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Asp.NetCore.EF.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Asp.NetCore.EF.Model.Blog", b =>
                {
                    b.HasOne("Asp.NetCore.EF.Model.User", "BlogAuthor")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Asp.NetCore.EF.Model.Role", b =>
                {
                    b.HasOne("Asp.NetCore.EF.Model.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
