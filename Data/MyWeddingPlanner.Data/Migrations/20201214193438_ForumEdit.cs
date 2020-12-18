namespace MyWeddingPlanner.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ForumEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_ForumPosts_PostId1",
                table: "ForumComments");

            migrationBuilder.RenameColumn(
                name: "PostId1",
                table: "ForumComments",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumComments_PostId1",
                table: "ForumComments",
                newName: "IX_ForumComments_ParentId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "ForumComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumComments_PostId",
                table: "ForumComments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_ForumComments_ParentId",
                table: "ForumComments",
                column: "ParentId",
                principalTable: "ForumComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_ForumPosts_PostId",
                table: "ForumComments",
                column: "PostId",
                principalTable: "ForumPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_ForumComments_ParentId",
                table: "ForumComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_ForumPosts_PostId",
                table: "ForumComments");

            migrationBuilder.DropIndex(
                name: "IX_ForumComments_PostId",
                table: "ForumComments");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "ForumComments",
                newName: "PostId1");

            migrationBuilder.RenameIndex(
                name: "IX_ForumComments_ParentId",
                table: "ForumComments",
                newName: "IX_ForumComments_PostId1");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "ForumComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_ForumPosts_PostId1",
                table: "ForumComments",
                column: "PostId1",
                principalTable: "ForumPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
