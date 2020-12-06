namespace MyWeddingPlanner.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsForSale_ItemsCategories_ItemsCategoryId",
                table: "ItemsForSale");

            migrationBuilder.DropIndex(
                name: "IX_ItemsForSale_ItemsCategoryId",
                table: "ItemsForSale");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ItemsForSale");

            migrationBuilder.DropColumn(
                name: "ItemsCategoryId",
                table: "ItemsForSale");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ItemsForSale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsForSale_CategoryId",
                table: "ItemsForSale",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsForSale_ItemsCategories_CategoryId",
                table: "ItemsForSale",
                column: "CategoryId",
                principalTable: "ItemsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsForSale_ItemsCategories_CategoryId",
                table: "ItemsForSale");

            migrationBuilder.DropIndex(
                name: "IX_ItemsForSale_CategoryId",
                table: "ItemsForSale");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ItemsForSale");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ItemsForSale",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemsCategoryId",
                table: "ItemsForSale",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsForSale_ItemsCategoryId",
                table: "ItemsForSale",
                column: "ItemsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsForSale_ItemsCategories_ItemsCategoryId",
                table: "ItemsForSale",
                column: "ItemsCategoryId",
                principalTable: "ItemsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
