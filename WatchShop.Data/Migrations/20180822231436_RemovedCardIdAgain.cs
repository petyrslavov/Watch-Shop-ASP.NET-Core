using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchShop.Web.Data.Migrations
{
    public partial class RemovedCardIdAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardId",
                table: "CartItems",
                nullable: true);
        }
    }
}
