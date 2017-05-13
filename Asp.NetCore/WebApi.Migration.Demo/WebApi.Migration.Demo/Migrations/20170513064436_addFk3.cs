using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk3 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Lodging",
                newName: "DestinationDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Lodging_DestinationId",
                table: "Lodging",
                newName: "IX_Lodging_DestinationDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_DestinationDestinationId",
                table: "Lodging",
                column: "DestinationDestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestinationDestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "DestinationDestinationId",
                table: "Lodging",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Lodging_DestinationDestinationId",
                table: "Lodging",
                newName: "IX_Lodging_DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_DestinationId",
                table: "Lodging",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
