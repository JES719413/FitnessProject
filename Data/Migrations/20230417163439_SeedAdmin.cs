using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness__Project.Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9b403ed-b85b-422b-8541-a637bb48e07c", "e045f663-f908-4bcf-8bf4-89a7efde13cd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b403ed-b85b-422b-8541-a637bb48e07c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e045f663-f908-4bcf-8bf4-89a7efde13cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9db51c6f-60d4-4b81-a46a-03f7fea006c5", "3303ab96-61fe-43eb-a076-44e06a2bfa6f", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ccb3a34-c19a-4de6-9116-5d31cf22a0b5", 0, "1a350005-49d7-4152-af5e-d883287d8941", "Admin@admin.com", true, false, null, "Admin@admin.com", "Admin@admin.com", "AQAAAAEAACcQAAAAEAzAkMLGWvYY2q7Od6cVQgBY65Ns0fiTucD6YXulBTztmx8l1Pydgc5eUpiQVPOwvQ==", null, false, "c7496ea0-9e31-43ae-98a8-ded4cb693868", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9db51c6f-60d4-4b81-a46a-03f7fea006c5", "1ccb3a34-c19a-4de6-9116-5d31cf22a0b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9db51c6f-60d4-4b81-a46a-03f7fea006c5", "1ccb3a34-c19a-4de6-9116-5d31cf22a0b5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9db51c6f-60d4-4b81-a46a-03f7fea006c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ccb3a34-c19a-4de6-9116-5d31cf22a0b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9b403ed-b85b-422b-8541-a637bb48e07c", "1b3b0dc9-4a58-4cee-a864-3aafb8296048", "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e045f663-f908-4bcf-8bf4-89a7efde13cd", 0, "22580347-be59-46ef-a052-804ef321e0b3", "Admin@admin.com", true, false, null, "Admin@admin.com", "Admin@admin.com", "AQAAAAEAACcQAAAAEGl9bSQkIvuqA55SthDVA3je2kUUaixehQZWEItjDurp1NVcpQteu+M6WrIwJKcLHA==", null, false, "b41952b7-d5c1-4b9f-bee0-aa8a85ced8c4", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9b403ed-b85b-422b-8541-a637bb48e07c", "e045f663-f908-4bcf-8bf4-89a7efde13cd" });
        }
    }
}
