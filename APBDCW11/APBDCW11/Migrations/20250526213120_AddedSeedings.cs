using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBDCW11.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "maria.wojcik@gmail.com", "Maria", "Wójcik" },
                    { 2, "tomasz.zielinski@gmail.com", "Tomasz", "Zieliński" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Reduces fever and pain", "Paracetamol", "OTC" },
                    { 2, "Used to treat type 2 diabetes", "Metformin", "Prescription" },
                    { 3, "Antihistamine for allergies", "Cetirizine", "OTC" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1978, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katarzyna", "Nowak" },
                    { 2, new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Kowalczyk" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Take one tablet every 6 hours", 1 },
                    { 2, 2, "Take with meals", 2 },
                    { 3, 1, "Take once daily", 1 },
                    { 3, 3, "Use as needed for allergy symptoms", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);
        }
    }
}
