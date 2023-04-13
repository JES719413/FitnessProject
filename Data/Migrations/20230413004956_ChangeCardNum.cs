using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness__Project.Data.Migrations
{
    public partial class ChangeCardNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<long>(
                name: "cardNum",
                table: "cardInfo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<int>(
                name: "cardNum",
                table: "cardInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
