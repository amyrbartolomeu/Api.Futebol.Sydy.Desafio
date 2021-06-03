using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionaLideresCampeonatoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Campeao",
                table: "Campeonato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerceiroLugar",
                table: "Campeonato",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViceCampeao",
                table: "Campeonato",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Campeao",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "TerceiroLugar",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "ViceCampeao",
                table: "Campeonato");
        }
    }
}
