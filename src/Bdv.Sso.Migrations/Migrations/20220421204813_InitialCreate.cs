using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bdv.Sso.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    password_salt = table.Column<string>(type: "text", nullable: true),
                    is_need_change_password = table.Column<bool>(type: "boolean", nullable: true),
                    is_email_confirmed = table.Column<bool>(type: "boolean", nullable: true),
                    is_phone_confirmed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_email_confirmed", "is_need_change_password", "is_phone_confirmed", "login", "password", "password_salt", "phone" },
                values: new object[] { new Guid("55197c22-0d7c-48f6-90c3-6870f761f87c"), null, null, true, null, "admin", null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
