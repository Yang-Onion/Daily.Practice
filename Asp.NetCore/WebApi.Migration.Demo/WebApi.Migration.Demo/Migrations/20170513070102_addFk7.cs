using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk7 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryContactForId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryContactId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondContactForId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondContactId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_PrimaryContactForId",
                table: "Lodging",
                column: "PrimaryContactForId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_PrimaryContactId",
                table: "Lodging",
                column: "PrimaryContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_SecondContactForId",
                table: "Lodging",
                column: "SecondContactForId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_SecondContactId",
                table: "Lodging",
                column: "SecondContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Person_PrimaryContactForId",
                table: "Lodging",
                column: "PrimaryContactForId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Person_PrimaryContactId",
                table: "Lodging",
                column: "PrimaryContactId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Person_SecondContactForId",
                table: "Lodging",
                column: "SecondContactForId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Person_SecondContactId",
                table: "Lodging",
                column: "SecondContactId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_PrimaryContactId",
                table: "Lodging");

            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_SecondContactForId",
                table: "Lodging");

            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_SecondContactId",
                table: "Lodging");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_PrimaryContactId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_SecondContactForId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_SecondContactId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "PrimaryContactId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "SecondContactForId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "SecondContactId",
                table: "Lodging");
        }
    }
}
