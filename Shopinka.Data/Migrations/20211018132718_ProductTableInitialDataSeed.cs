using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopinka.Migrations
{
    public partial class ProductTableInitialDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUri", "Name", "Price" },
                values: new object[,]
                {
                    { 2, "Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. ", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Karamelový anjelik", 0.69m },
                    { 3, "Chrumkavá vášeň ukrytá v čokoláde. Jemná príchuť kubánskeho rumu.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Rumová chrumka", 2.69m },
                    { 4, "Chrumkavá vášeň ukrytá v čokoláde. Dotyk jahôdok. ", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Jahodová chrumka", 1.69m },
                    { 5, "Vášeň ukrytá v čokoláde. Okoreňte si svoj život. ", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Čili chrumka", 0.39m },
                    { 6, "Vášeň ukrytá v čokoláde. Espresso shot v čokoláde. ", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Kávička v čokoláde", 2.39m },
                    { 7, "Prekvapenie.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Double trouble", 1.39m },
                    { 8, "Zážitok.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Agent Provocateur", 0.79m },
                    { 9, "Najpredávanejšia pralinka.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Mandľové praliné", 2.79m },
                    { 10, "Luxusná variácia najpredávanejšej pralinky.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Lieskovoorieškové praliné", 1.79m },
                    { 11, "Čokoládová ganache s dotykom najkvalitnejšej borovičky.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Čože je to borovička", 0.49m },
                    { 12, "Čokoládová ganache s dotykom najkvalitnejšej slivovičky.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Čože je to slivovička", 2.49m },
                    { 13, "Herbal infusion. Upokojujúca chuť harmančeka v sladkom objatí bielej čokolády.", "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg", "Harmančekové pohladenie", 1.49m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
