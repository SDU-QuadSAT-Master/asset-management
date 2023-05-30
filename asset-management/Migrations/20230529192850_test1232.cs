using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asset_management.Migrations
{
    /// <inheritdoc />
    public partial class test1232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Antennas");

            migrationBuilder.RenameColumn(
                name: "Organization",
                table: "Drones",
                newName: "Model");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Drones",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Antennas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Drones");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Antennas");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Drones",
                newName: "Organization");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Antennas",
                type: "text",
                nullable: true);
        }
    }
}
