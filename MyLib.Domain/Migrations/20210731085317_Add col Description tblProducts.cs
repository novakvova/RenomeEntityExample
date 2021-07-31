using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLib.Migrations
{
    public partial class AddcolDescriptiontblProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblProducts",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblProducts");
        }
    }
}
