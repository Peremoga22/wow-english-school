using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowApp.Migrations
{
    /// <inheritdoc />
    public partial class MakePortfolioAppointmentNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId",
                table: "Portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Portfolios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AppointmentId1",
                table: "Portfolios",
                column: "AppointmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId",
                table: "Portfolios",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId1",
                table: "Portfolios",
                column: "AppointmentId1",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId1",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_AppointmentId1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "AppointmentId1",
                table: "Portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Appointments_AppointmentId",
                table: "Portfolios",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
