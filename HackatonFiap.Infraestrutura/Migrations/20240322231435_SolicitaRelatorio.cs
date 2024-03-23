using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackatonFiap.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class SolicitaRelatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ponto_funcionario_FuncionarioId",
                table: "ponto");

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "ponto",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "solicitaPonto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitaPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitaPonto_Funcionario",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_solicitaPonto_FuncionarioId",
                table: "solicitaPonto",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ponto_Funcionario",
                table: "ponto",
                column: "FuncionarioId",
                principalTable: "funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ponto_Funcionario",
                table: "ponto");

            migrationBuilder.DropTable(
                name: "solicitaPonto");

            migrationBuilder.AlterColumn<Guid>(
                name: "FuncionarioId",
                table: "ponto",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_ponto_funcionario_FuncionarioId",
                table: "ponto",
                column: "FuncionarioId",
                principalTable: "funcionario",
                principalColumn: "Id");
        }
    }
}
