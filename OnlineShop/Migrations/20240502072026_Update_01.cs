#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class Update_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Managers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
