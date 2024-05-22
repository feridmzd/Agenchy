using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAgency.Migrations
{
    /// <inheritdoc />
    public partial class Creatctr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Portfolies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Portfolies");
        }
    }
}
