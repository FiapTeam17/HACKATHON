using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackatonFiap.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class CriaCampoTipoRegistro : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "tipo",
                table: "ponto",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "ponto");

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
