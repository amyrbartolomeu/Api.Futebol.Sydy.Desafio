using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeUmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeDoisId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GolsTimeUm = table.Column<int>(type: "int", nullable: false),
                    GolsTimeDois = table.Column<int>(type: "int", nullable: false),
                    CampeonatoEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Campeonato_CampeonatoEntityId",
                        column: x => x.CampeonatoEntityId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Time_TimeDoisId",
                        column: x => x.TimeDoisId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Time_TimeUmId",
                        column: x => x.TimeUmId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontuacaoCampeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampeonatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontuacaoCampeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Campeonato_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_CampeonatoEntityId",
                table: "Partidas",
                column: "CampeonatoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeDoisId",
                table: "Partidas",
                column: "TimeDoisId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeUmId",
                table: "Partidas",
                column: "TimeUmId");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_CampeonatoId",
                table: "PontuacaoCampeonato",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_TimeId",
                table: "PontuacaoCampeonato",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_Nome",
                table: "Time",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "PontuacaoCampeonato");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
