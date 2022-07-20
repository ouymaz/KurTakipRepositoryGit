using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaprazKurs",
                columns: table => new
                {
                    DovizKodu = table.Column<string>(type: "text", nullable: false),
                    Birim = table.Column<int>(type: "integer", nullable: false),
                    DovizCinsiV1 = table.Column<string>(type: "text", nullable: true),
                    DovizCinsiV2 = table.Column<string>(type: "text", nullable: true),
                    CaprazKurDeger = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaprazKurs", x => x.DovizKodu);
                });

            migrationBuilder.CreateTable(
                name: "DovizKurus",
                columns: table => new
                {
                    DovizKodu = table.Column<string>(type: "text", nullable: false),
                    Birim = table.Column<int>(type: "integer", nullable: false),
                    DovizCinsi = table.Column<string>(type: "text", nullable: true),
                    DovizAlis = table.Column<double>(type: "double precision", nullable: false),
                    DovizSatis = table.Column<double>(type: "double precision", nullable: false),
                    EfektifAlis = table.Column<double>(type: "double precision", nullable: false),
                    EfektifSatis = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovizKurus", x => x.DovizKodu);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaprazKurs");

            migrationBuilder.DropTable(
                name: "DovizKurus");
        }
    }
}
