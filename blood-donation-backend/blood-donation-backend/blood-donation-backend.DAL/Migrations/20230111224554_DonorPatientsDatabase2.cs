using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blooddonationbackend.Migrations
{
    /// <inheritdoc />
    public partial class DonorPatientsDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentDonorId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CurrentDonorId",
                table: "Patients",
                column: "CurrentDonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients",
                column: "CurrentDonorId",
                principalTable: "Donors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_CurrentDonorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CurrentDonorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
