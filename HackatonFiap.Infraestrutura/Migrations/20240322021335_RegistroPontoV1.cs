using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackatonFiap.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class RegistroPontoV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ponto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Horario = table.Column<DateTime>(type: "datetime(6)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ponto_funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionario",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ponto_FuncionarioId",
                table: "ponto",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ponto");
        }
    }
}
