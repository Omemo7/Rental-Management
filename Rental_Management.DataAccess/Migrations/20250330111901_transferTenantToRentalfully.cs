using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class transferTenantToRentalfully : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentsRentals_Tenants_TenantId",
                table: "ApartmentsRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsRentals_Tenants_TenantId",
                table: "CarsRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomRentals_Tenants_TenantId",
                table: "CustomRentals");

            migrationBuilder.DropIndex(
                name: "IX_CustomRentals_TenantId",
                table: "CustomRentals");

            migrationBuilder.DropIndex(
                name: "IX_CarsRentals_TenantId",
                table: "CarsRentals");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentsRentals_TenantId",
                table: "ApartmentsRentals");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CustomRentals");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CarsRentals");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "ApartmentsRentals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CustomRentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "CarsRentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "ApartmentsRentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomRentals_TenantId",
                table: "CustomRentals",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsRentals_TenantId",
                table: "CarsRentals",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentsRentals_TenantId",
                table: "ApartmentsRentals",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentsRentals_Tenants_TenantId",
                table: "ApartmentsRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsRentals_Tenants_TenantId",
                table: "CarsRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRentals_Tenants_TenantId",
                table: "CustomRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }
    }
}
