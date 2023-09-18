using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RezervasyonSonuclari",
                columns: table => new
                {
                    RezervasyonSonucuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonIstegiID = table.Column<int>(type: "int", nullable: false),
                    RezervasyonYapilabilir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervasyonSonuclari", x => x.RezervasyonSonucuID);
                });

            migrationBuilder.CreateTable(
                name: "Trenler",
                columns: table => new
                {
                    TrenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenler", x => x.TrenID);
                });

            migrationBuilder.CreateTable(
                name: "YerlesimAyrintilari",
                columns: table => new
                {
                    YerlesimAyrintiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervasyonIstegiID = table.Column<int>(type: "int", nullable: false),
                    VagonAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiSayisi = table.Column<int>(type: "int", nullable: false),
                    RezervasyonSonucuID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YerlesimAyrintilari", x => x.YerlesimAyrintiID);
                    table.ForeignKey(
                        name: "FK_YerlesimAyrintilari_RezervasyonSonuclari_RezervasyonSonucuID",
                        column: x => x.RezervasyonSonucuID,
                        principalTable: "RezervasyonSonuclari",
                        principalColumn: "RezervasyonSonucuID");
                });

            migrationBuilder.CreateTable(
                name: "rezervasyonIstekleri",
                columns: table => new
                {
                    RezervasyonIstegiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenID = table.Column<int>(type: "int", nullable: false),
                    RezervasyonYapilacakKisiSayisi = table.Column<int>(type: "int", nullable: false),
                    KisilerFarkliVagonlaraYerlestirilebilir = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervasyonIstekleri", x => x.RezervasyonIstegiID);
                    table.ForeignKey(
                        name: "FK_rezervasyonIstekleri_Trenler_TrenID",
                        column: x => x.TrenID,
                        principalTable: "Trenler",
                        principalColumn: "TrenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vagonlar",
                columns: table => new
                {
                    VagonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapasite = table.Column<int>(type: "int", nullable: false),
                    DoluKoltukAdet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagonlar", x => x.VagonID);
                    table.ForeignKey(
                        name: "FK_Vagonlar_Trenler_TrenID",
                        column: x => x.TrenID,
                        principalTable: "Trenler",
                        principalColumn: "TrenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trenler",
                columns: new[] { "TrenID", "Ad" },
                values: new object[] { 1, "Başkent Ekspres" });

            migrationBuilder.InsertData(
                table: "Vagonlar",
                columns: new[] { "VagonID", "Ad", "DoluKoltukAdet", "Kapasite", "TrenID" },
                values: new object[,]
                {
                    { 1, "Vagon 1", 68, 100, 1 },
                    { 2, "Vagon 2", 50, 90, 1 },
                    { 3, "Vagon 3", 60, 60, 1 },
                    { 4, "Vagon 4", 25, 70, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_rezervasyonIstekleri_TrenID",
                table: "rezervasyonIstekleri",
                column: "TrenID");

            migrationBuilder.CreateIndex(
                name: "IX_Vagonlar_TrenID",
                table: "Vagonlar",
                column: "TrenID");

            migrationBuilder.CreateIndex(
                name: "IX_YerlesimAyrintilari_RezervasyonSonucuID",
                table: "YerlesimAyrintilari",
                column: "RezervasyonSonucuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rezervasyonIstekleri");

            migrationBuilder.DropTable(
                name: "Vagonlar");

            migrationBuilder.DropTable(
                name: "YerlesimAyrintilari");

            migrationBuilder.DropTable(
                name: "Trenler");

            migrationBuilder.DropTable(
                name: "RezervasyonSonuclari");
        }
    }
}
