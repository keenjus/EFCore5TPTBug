using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore5TPTBug.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "referral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("referral_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_referral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("referral_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_referral_referral_Id",
                        column: x => x.Id,
                        principalTable: "referral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_referral");

            migrationBuilder.DropTable(
                name: "referral");
        }
    }
}
