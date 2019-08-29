using Microsoft.EntityFrameworkCore.Migrations;

namespace WatchShop.Web.Data.Migrations
{
    public partial class AddPhoneNumberProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "PendingOrders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PendingOrders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PendingOrders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PendingOrders");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "PendingOrders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "PendingOrders",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
