using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCultureField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCulture",
                table: "HomeSections",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCulture",
                table: "HomeSections");
        }
    }
}
