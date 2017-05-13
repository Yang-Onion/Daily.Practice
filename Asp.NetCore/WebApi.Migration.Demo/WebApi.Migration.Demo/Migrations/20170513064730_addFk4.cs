using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk4 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestinationDestinationId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_DestinationDestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "DestinationDestinationId",
                table: "Lodging",
                newName: "DestId");

            migrationBuilder.AddColumn<int>(
                name: "TargetDestinationId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_TargetDestinationId",
                table: "Lodging",
                column: "TargetDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_TargetDestinationId",
                table: "Lodging",
                column: "TargetDestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_TargetDestinationId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_TargetDestinationId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "TargetDestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "DestId",
                table: "Lodging",
                newName: "DestinationDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_DestinationDestinationId",
                table: "Lodging",
                column: "DestinationDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_DestinationDestinationId",
                table: "Lodging",
                column: "DestinationDestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
