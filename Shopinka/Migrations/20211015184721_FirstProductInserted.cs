using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopinka.Migrations
{
    public partial class FirstProductInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUri", "Name", "Price" },
                values: new object[] { "Vášeň ukrytá v čokoláde. Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. ", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Arónia osudu", 1.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUri", "Name", "Price" },
                values: new object[] { "", "", "John Doe", 5m });
        }
    }
}
