using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blooddonationbackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "PatientMedicines");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PatientMedicines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PatientMedicines");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "PatientDoctor");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "PatientDoctor");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Patients",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PatientDoctor",
                newName: "PatientDoctorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Medicines",
                newName: "MedicineId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Donors",
                newName: "DonorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "DoctorId");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientMedicineId",
                table: "PatientMedicines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientMedicineId",
                table: "PatientMedicines");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Tests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PatientDoctorId",
                table: "PatientDoctor",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "Medicines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DonorId",
                table: "Donors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Tests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PatientMedicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PatientMedicines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PatientMedicines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PatientDoctor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "PatientDoctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Medicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Medicines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Donors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Donors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Doctors",
                type: "datetime2",
                nullable: true);
        }
    }
}
