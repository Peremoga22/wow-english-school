using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoTitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PhotoText = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    ImgLeftPath = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    ImgCenterPath = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    ImgRightPath = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    ChristmasTitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ChristmasText = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeSections");
        }
    }
}
