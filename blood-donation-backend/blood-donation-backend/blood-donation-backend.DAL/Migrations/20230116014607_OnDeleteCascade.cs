using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blooddonationbackend.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Doctors_DoctorId",
                table: "Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients",
                column: "CurrentDonorId",
                principalTable: "Donors",
                principalColumn: "DonorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Doctors_DoctorId",
                table: "Tests",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Doctors_DoctorId",
                table: "Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Donors_CurrentDonorId",
                table: "Patients",
                column: "CurrentDonorId",
                principalTable: "Donors",
                principalColumn: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Doctors_DoctorId",
                table: "Tests",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }
    }
}
