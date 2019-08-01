using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchShop.Web.Data.Migrations
{
    public partial class AddedCardId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "CartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CartItems");
        }
    }
}
