using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixedRentalRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomRentals_RentalId",
                table: "CustomRentals");

            migrationBuilder.DropIndex(
                name: "IX_CarsRentals_RentalId",
                table: "CarsRentals");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentsRentals_RentalId",
                table: "ApartmentsRentals");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRentals_RentalId",
                table: "CustomRentals",
                column: "RentalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarsRentals_RentalId",
                table: "CarsRentals",
                column: "RentalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsRentals_RentalId",
                table: "ApartmentsRentals",
                column: "RentalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomRentals_RentalId",
                table: "CustomRentals");

            migrationBuilder.DropIndex(
                name: "IX_CarsRentals_RentalId",
                table: "CarsRentals");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentsRentals_RentalId",
                table: "ApartmentsRentals");

            migrationBuilder.CreateIndex(
                name: "IX_CustomRentals_RentalId",
                table: "CustomRentals",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsRentals_RentalId",
                table: "CarsRentals",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsRentals_RentalId",
                table: "ApartmentsRentals",
                column: "RentalId");
        }
    }
}
