using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Naves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passageiro = table.Column<int>(type: "int", nullable: false),
                    Carga = table.Column<double>(type: "float", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PilotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naves_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rotacao = table.Column<double>(type: "float", nullable: false),
                    Orbita = table.Column<double>(type: "float", nullable: false),
                    Diametro = table.Column<double>(type: "float", nullable: false),
                    Clima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Populacao = table.Column<long>(type: "bigint", nullable: false),
                    PilotoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planetas_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NavePilotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNave = table.Column<int>(type: "int", nullable: false),
                    IdPiloto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavePilotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavePilotos_Naves_IdNave",
                        column: x => x.IdNave,
                        principalTable: "Naves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavePilotos_Pilotos_IdPiloto",
                        column: x => x.IdPiloto,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotoPlanetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPiloto = table.Column<int>(type: "int", nullable: false),
                    IdPlaneta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotoPlanetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotoPlanetas_Pilotos_IdPiloto",
                        column: x => x.IdPiloto,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilotoPlanetas_Planetas_IdPlaneta",
                        column: x => x.IdPlaneta,
                        principalTable: "Planetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavePilotos_IdNave",
                table: "NavePilotos",
                column: "IdNave");

            migrationBuilder.CreateIndex(
                name: "IX_NavePilotos_IdPiloto",
                table: "NavePilotos",
                column: "IdPiloto");

            migrationBuilder.CreateIndex(
                name: "IX_Naves_PilotoId",
                table: "Naves",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotoPlanetas_IdPiloto",
                table: "PilotoPlanetas",
                column: "IdPiloto");

            migrationBuilder.CreateIndex(
                name: "IX_PilotoPlanetas_IdPlaneta",
                table: "PilotoPlanetas",
                column: "IdPlaneta");

            migrationBuilder.CreateIndex(
                name: "IX_Planetas_PilotoId",
                table: "Planetas",
                column: "PilotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavePilotos");

            migrationBuilder.DropTable(
                name: "PilotoPlanetas");

            migrationBuilder.DropTable(
                name: "Naves");

            migrationBuilder.DropTable(
                name: "Planetas");

            migrationBuilder.DropTable(
                name: "Pilotos");
        }
    }
}
