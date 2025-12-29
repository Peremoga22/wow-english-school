using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WowApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedServiceClientReqired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId",
                table: "ServiceClients");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "ServiceClients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId1",
                table: "ServiceClients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceClients_AppointmentId1",
                table: "ServiceClients",
                column: "AppointmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId",
                table: "ServiceClients",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId1",
                table: "ServiceClients",
                column: "AppointmentId1",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId",
                table: "ServiceClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId1",
                table: "ServiceClients");

            migrationBuilder.DropIndex(
                name: "IX_ServiceClients_AppointmentId1",
                table: "ServiceClients");

            migrationBuilder.DropColumn(
                name: "AppointmentId1",
                table: "ServiceClients");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "ServiceClients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceClients_Appointments_AppointmentId",
                table: "ServiceClients",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
