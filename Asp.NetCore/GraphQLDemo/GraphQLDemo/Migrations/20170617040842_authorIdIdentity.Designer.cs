using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GraphQLDemo.Model;

namespace GraphQLDemo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170617040842_authorIdIdentity")]
    partial class authorIdIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQLDemo.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SecondName")
                        .HasColumnName("NickName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("GraphQLDemo.Model.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Isbn");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("GraphQLDemo.Model.Book", b =>
                {
                    b.HasOne("GraphQLDemo.Model.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });
        }
    }
}
