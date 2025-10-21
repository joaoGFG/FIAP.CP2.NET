using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.CP2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarContasETransacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    NomeTitular = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoConta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Saldo = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    Ativa = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroConta = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ContaId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ContaDestinoId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SaldoAnterior = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    SaldoPosterior = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
