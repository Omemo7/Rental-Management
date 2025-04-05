using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class transferTenantToRental : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CustomRentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CarsRentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "ApartmentsRentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_TenantId",
                table: "Rentals",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_TenantId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Rentals");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CustomRentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "CarsRentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "ApartmentsRentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentsRentals_Tenants_TenantId",
                table: "ApartmentsRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsRentals_Tenants_TenantId",
                table: "CarsRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomRentals_Tenants_TenantId",
                table: "CustomRentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
