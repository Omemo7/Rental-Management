using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addRentPaymentFrequencyClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentPaymentFrequency",
                table: "Rentals",
                newName: "RentPaymentFrequencyId");

            migrationBuilder.CreateTable(
                name: "RentPaymentFrequency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPaymentFrequency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RentPaymentFrequencyId",
                table: "Rentals",
                column: "RentPaymentFrequencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_RentPaymentFrequency_RentPaymentFrequencyId",
                table: "Rentals",
                column: "RentPaymentFrequencyId",
                principalTable: "RentPaymentFrequency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_RentPaymentFrequency_RentPaymentFrequencyId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "RentPaymentFrequency");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_RentPaymentFrequencyId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "RentPaymentFrequencyId",
                table: "Rentals",
                newName: "RentPaymentFrequency");
        }
    }
}
