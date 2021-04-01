using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortnerApi.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShortUrls",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShortUrls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortKey",
                table: "ShortUrls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls",
                column: "ShortKey");
        }
    }
}
