using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicAPI.Migrations
{
    /// <inheritdoc />
    public partial class Breakfast_NewProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_breakfast",
                table: "breakfast");

            migrationBuilder.RenameTable(
                name: "breakfast",
                newName: "Breakfast");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Breakfast",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Breakfast",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breakfast",
                table: "Breakfast",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Breakfast",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Breakfast");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Breakfast");

            migrationBuilder.RenameTable(
                name: "Breakfast",
                newName: "breakfast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_breakfast",
                table: "breakfast",
                column: "Id");
        }
    }
}
