﻿namespace MyWeddingPlanner.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class OneMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ItemsForSale",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemsForSale");
        }
    }
}
