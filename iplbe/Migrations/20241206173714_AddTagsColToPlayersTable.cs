using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iplbe.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsColToPlayersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Death",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dependable",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Finisher",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFastBowler",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpinner",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Middle",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Newball",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Opener",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Death",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Dependable",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Finisher",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsFastBowler",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsSpinner",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Middle",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Newball",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Opener",
                table: "Players");
        }
    }
}
