using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcheASaida.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Pontuacao = table.Column<int>(type: "INTEGER", nullable: false),
                    LabirintosConcluidos = table.Column<string>(type: "TEXT", nullable: false),
                    QtdLabirintosConcluidos = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaExploracao = table.Column<decimal>(type: "TEXT", nullable: false),
                    MediaPassos = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoLabirintos",
                columns: table => new
                {
                    IdLabirinto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dificuldade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Completo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Passos = table.Column<int>(type: "INTEGER", nullable: false),
                    PorcentagemExploracao = table.Column<decimal>(type: "TEXT", nullable: false),
                    GrupoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoLabirintos", x => x.IdLabirinto);
                    table.ForeignKey(
                        name: "FK_InfoLabirintos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Labirintos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dificuldade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EntradaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labirintos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vertices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Labirinto = table.Column<int>(type: "INTEGER", nullable: false),
                    LabirintoId = table.Column<int>(type: "INTEGER", nullable: true),
                    VerticeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vertices_Labirintos_LabirintoId",
                        column: x => x.LabirintoId,
                        principalTable: "Labirintos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vertices_Vertices_VerticeId",
                        column: x => x.VerticeId,
                        principalTable: "Vertices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoLabirintos_GrupoId",
                table: "InfoLabirintos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Labirintos_EntradaId",
                table: "Labirintos",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_LabirintoId",
                table: "Vertices",
                column: "LabirintoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_VerticeId",
                table: "Vertices",
                column: "VerticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Labirintos_Vertices_EntradaId",
                table: "Labirintos",
                column: "EntradaId",
                principalTable: "Vertices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labirintos_Vertices_EntradaId",
                table: "Labirintos");

            migrationBuilder.DropTable(
                name: "InfoLabirintos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Vertices");

            migrationBuilder.DropTable(
                name: "Labirintos");
        }
    }
}
