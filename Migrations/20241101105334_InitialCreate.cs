using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OPC.UAFx.Client.Service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaquinaOees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    EstadoMaquina = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducaoTotal = table.Column<uint>(type: "INTEGER", nullable: false),
                    CiclosTotal = table.Column<ulong>(type: "INTEGER", nullable: false),
                    MinutosTotal = table.Column<ulong>(type: "INTEGER", nullable: false),
                    RejeitosTotal = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaOees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaquinaOees");
        }
    }
}
