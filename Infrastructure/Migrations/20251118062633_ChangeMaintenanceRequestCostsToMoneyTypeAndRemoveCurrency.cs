using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaintenanceRequestCostsToMoneyTypeAndRemoveCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "MaintenanceRequests",
                newName: "PartsCost_Currency");

            migrationBuilder.RenameColumn(
                name: "PartsCost",
                table: "MaintenanceRequests",
                newName: "PartsCost_Amount");

            migrationBuilder.RenameColumn(
                name: "LaborCost",
                table: "MaintenanceRequests",
                newName: "LaborCost_Amount");

            migrationBuilder.AlterColumn<string>(
                name: "PartsCost_Currency",
                table: "MaintenanceRequests",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3);

            migrationBuilder.AddColumn<string>(
                name: "LaborCost_Currency",
                table: "MaintenanceRequests",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LaborCost_Currency",
                table: "MaintenanceRequests");

            migrationBuilder.RenameColumn(
                name: "PartsCost_Currency",
                table: "MaintenanceRequests",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "PartsCost_Amount",
                table: "MaintenanceRequests",
                newName: "PartsCost");

            migrationBuilder.RenameColumn(
                name: "LaborCost_Amount",
                table: "MaintenanceRequests",
                newName: "LaborCost");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "MaintenanceRequests",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
