using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk2 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_TargetDestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "TargetDestinationId",
                table: "Lodging",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Lodging_TargetDestinationId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestinationId",
                table: "Lodging");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Lodging",
                newName: "TargetDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Lodging_DestinationId",
                table: "Lodging",
                newName: "IX_Lodging_TargetDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_TargetDestinationId",
                table: "Lodging",
                column: "TargetDestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
