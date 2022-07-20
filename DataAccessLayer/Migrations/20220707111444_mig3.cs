using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaprazKurs");

            migrationBuilder.DropColumn(
                name: "DovizAlis",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "DovizSatis",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "EfektifAlis",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "EfektifSatis",
                table: "DovizKurus");

            migrationBuilder.RenameColumn(
                name: "DovizCinsi",
                table: "DovizKurus",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Birim",
                table: "DovizKurus",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "DovizKodu",
                table: "DovizKurus",
                newName: "CurrencyCode");

            migrationBuilder.AddColumn<string>(
                name: "BanknoteBuying",
                table: "DovizKurus",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BanknoteSelling",
                table: "DovizKurus",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrossRateOther",
                table: "DovizKurus",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CrossRateUSD",
                table: "DovizKurus",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ForexBuying",
                table: "DovizKurus",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ForexSelling",
                table: "DovizKurus",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanknoteBuying",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "BanknoteSelling",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "CrossRateOther",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "CrossRateUSD",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "ForexBuying",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "ForexSelling",
                table: "DovizKurus");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "DovizKurus",
                newName: "Birim");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DovizKurus",
                newName: "DovizCinsi");

            migrationBuilder.RenameColumn(
                name: "CurrencyCode",
                table: "DovizKurus",
                newName: "DovizKodu");

            migrationBuilder.AddColumn<double>(
                name: "DovizAlis",
                table: "DovizKurus",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DovizSatis",
                table: "DovizKurus",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EfektifAlis",
                table: "DovizKurus",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EfektifSatis",
                table: "DovizKurus",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CaprazKurs",
                columns: table => new
                {
                    DovizKodu = table.Column<string>(type: "text", nullable: false),
                    Birim = table.Column<int>(type: "integer", nullable: false),
                    CaprazKurDeger = table.Column<double>(type: "double precision", nullable: false),
                    DovizCinsiV1 = table.Column<string>(type: "text", nullable: true),
                    DovizCinsiV2 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaprazKurs", x => x.DovizKodu);
                });
        }
    }
}
