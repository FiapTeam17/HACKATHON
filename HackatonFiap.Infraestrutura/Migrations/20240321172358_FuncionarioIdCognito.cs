using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackatonFiap.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioIdCognito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CognitoId",
                table: "funcionario",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CognitoId",
                table: "funcionario");
        }
    }
}
