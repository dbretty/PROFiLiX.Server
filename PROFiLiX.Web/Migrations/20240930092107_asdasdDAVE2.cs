using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROFiLiX.Web.Migrations
{
    /// <inheritdoc />
    public partial class asdasdDAVE2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionDescription",
                table: "ProfilixCustomAction",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionDescription",
                table: "ProfilixCustomAction");
        }
    }
}
