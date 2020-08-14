using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.CreateTable(
                name: "ShoppingItem",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    LastBought = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItem", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException(nameof(migrationBuilder));
            }

            migrationBuilder.DropTable(
                name: "ShoppingItem");
        }
    }
}
