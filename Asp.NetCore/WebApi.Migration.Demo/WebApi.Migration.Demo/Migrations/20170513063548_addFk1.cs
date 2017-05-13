using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migration.Demo.Migrations
{
    public partial class addFk1 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lodging_Destination_DestinationId",
                table: "Lodging");

            migrationBuilder.DropIndex(
                name: "IX_Lodging_DestinationId",
                table: "Lodging");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Lodging");

            migrationBuilder.AddColumn<int>(
                name: "TargetDestinationId",
                table: "Lodging",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Lodging",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lodging_DestinationId",
                table: "Lodging",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lodging_Destination_DestinationId",
                table: "Lodging",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
