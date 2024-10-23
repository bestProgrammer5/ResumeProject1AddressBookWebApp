using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApi.Migrations
{
    /// <inheritdoc />
    public partial class Changedemailvariabletype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactVariables",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "phoneNumber",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ContactVariables",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "phoneNumber",
                table: "ContactVariables",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
