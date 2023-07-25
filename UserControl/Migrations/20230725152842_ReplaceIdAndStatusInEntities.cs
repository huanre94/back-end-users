using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresentationLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceIdAndStatusInEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Pets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Owners",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pets",
                newName: "PetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owners",
                newName: "OwnerId");
        }
    }
}
