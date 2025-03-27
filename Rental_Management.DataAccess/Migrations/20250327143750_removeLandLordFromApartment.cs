using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeLandLordFromApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentBuildings_Landlords_landLordId",
                table: "ApartmentBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Landlords_LandLordId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LandLordId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "LandLordId",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "landLordId",
                table: "ApartmentBuildings",
                newName: "LandLordId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentBuildings_landLordId",
                table: "ApartmentBuildings",
                newName: "IX_ApartmentBuildings_LandLordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentBuildings_Landlords_LandLordId",
                table: "ApartmentBuildings",
                column: "LandLordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentBuildings_Landlords_LandLordId",
                table: "ApartmentBuildings");

            migrationBuilder.RenameColumn(
                name: "LandLordId",
                table: "ApartmentBuildings",
                newName: "landLordId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentBuildings_LandLordId",
                table: "ApartmentBuildings",
                newName: "IX_ApartmentBuildings_landLordId");

            migrationBuilder.AddColumn<int>(
                name: "LandLordId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LandLordId",
                table: "Apartments",
                column: "LandLordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentBuildings_Landlords_landLordId",
                table: "ApartmentBuildings",
                column: "landLordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Landlords_LandLordId",
                table: "Apartments",
                column: "LandLordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
