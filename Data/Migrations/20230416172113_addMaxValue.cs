using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness__Project.Data.Migrations
{
    public partial class addMaxValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "memberID",
                table: "cardInfo",
                type: "varchar(75)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "memberID",
                table: "cardInfo",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(75)");
        }
    }
}
