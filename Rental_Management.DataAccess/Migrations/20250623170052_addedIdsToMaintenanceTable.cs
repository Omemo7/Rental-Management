using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental_Management.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedIdsToMaintenanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Maintenances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Maintenances");
        }
    }
}
