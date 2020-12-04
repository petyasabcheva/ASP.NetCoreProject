namespace MyWeddingPlanner.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ImageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Vendors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
