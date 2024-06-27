#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class Update_09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Customers_CustomerId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "Basket");

            migrationBuilder.RenameIndex(
                name: "IX_Baskets_CustomerId",
                table: "Basket",
                newName: "IX_Basket_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Customers_CustomerId",
                table: "Basket",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Basket_BasketId",
                table: "Items",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Basket_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Customers_CustomerId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Basket_BasketId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Basket_BasketId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "Baskets");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_CustomerId",
                table: "Baskets",
                newName: "IX_Baskets_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Customers_CustomerId",
                table: "Baskets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "BasketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
