using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSomeVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "facebookLink",
                table: "ContactVariables");

            migrationBuilder.DropColumn(
                name: "fullAddress",
                table: "ContactVariables");

            migrationBuilder.DropColumn(
                name: "instagramLink",
                table: "ContactVariables");

            migrationBuilder.DropColumn(
                name: "linkedInLink",
                table: "ContactVariables");

            migrationBuilder.DropColumn(
                name: "twitterLink",
                table: "ContactVariables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "facebookLink",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullAddress",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "instagramLink",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "linkedInLink",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "twitterLink",
                table: "ContactVariables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
