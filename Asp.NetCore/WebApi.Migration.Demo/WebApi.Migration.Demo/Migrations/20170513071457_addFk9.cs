using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk9 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Person_SecondContactForId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_SecondContactForId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "PrimaryContactForId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "SecondContactForId",
                table: "Lodging");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryContactForId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondContactForId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_PrimaryContactForId",
                table: "Lodging",
                column: "PrimaryContactForId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_SecondContactForId",
                table: "Lodging",
                column: "SecondContactForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Person_PrimaryContactForId",
                table: "Lodging",
                column: "PrimaryContactForId",
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
        }
    }
}
