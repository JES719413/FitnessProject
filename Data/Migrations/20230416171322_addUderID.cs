using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness__Project.Data.Migrations
{
    public partial class addUderID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "memberID",
                table: "cardInfo",
                type: "varchar",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "memberID",
                table: "cardInfo");
        }
    }
}
