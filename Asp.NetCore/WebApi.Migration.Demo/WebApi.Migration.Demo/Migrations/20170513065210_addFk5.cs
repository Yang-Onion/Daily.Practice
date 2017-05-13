using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk5 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_DestId",
                table: "Lodging",
                column: "DestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_DestId",
                table: "Lodging",
                column: "DestId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_DestId",
                table: "Lodging");

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
    }
}
