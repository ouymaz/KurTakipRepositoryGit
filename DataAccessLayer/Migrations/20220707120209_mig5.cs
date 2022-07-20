using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DovizKurus",
                table: "DovizKurus");

            migrationBuilder.RenameColumn(
                name: "Mounth",
                table: "DovizKurus",
                newName: "Month");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "DovizKurus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "DovizKurus",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DovizKurus",
                table: "DovizKurus",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DovizKurus",
                table: "DovizKurus");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DovizKurus");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "DovizKurus",
                newName: "Mounth");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "DovizKurus",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DovizKurus",
                table: "DovizKurus",
                column: "CurrencyCode");
        }
    }
}
