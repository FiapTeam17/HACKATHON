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
            migrationBuilder.AddColumn<int>(
                name: "tipo",
                table: "ponto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "ponto");
        }
    }
}
