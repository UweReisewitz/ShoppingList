using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Database.Migrations
{
    public partial class UserInterface6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ShoppingItem",
                type: "BLOB",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "ShoppingItem",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ShoppingItem");

            migrationBuilder.DropIndex(
                name: "Idx_Name",
                table: "ShoppingItem");
        }
    }
}
