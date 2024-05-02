using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class Update_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops",
                column: "ManagerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ManagerId",
                table: "Shops",
                column: "ManagerId");
        }
    }
}
