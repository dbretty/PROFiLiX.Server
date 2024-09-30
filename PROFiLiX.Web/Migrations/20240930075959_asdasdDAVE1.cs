using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROFiLiX.Web.Migrations
{
    /// <inheritdoc />
    public partial class asdasdDAVE1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfilixCustomAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionName = table.Column<string>(type: "TEXT", nullable: false),
                    ActionType = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionContent = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilixCustomAction", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfilixCustomAction");
        }
    }
}
