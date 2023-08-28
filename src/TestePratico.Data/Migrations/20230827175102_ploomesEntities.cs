using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestePratico.Infra.Data.Migrations
{
    public partial class ploomesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(64)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(245)", nullable: false),
                    Salario = table.Column<decimal>(type: "Decimal(8,2)", nullable: false),
                    FkIdEmpresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaga_Empresa_FkIdEmpresa",
                        column: x => x.FkIdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidatura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FkIdVaga = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatura_Usuario_FkIdUsuario",
                        column: x => x.FkIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidatura_Vaga_FkIdVaga",
                        column: x => x.FkIdVaga,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatura_FkIdUsuario",
                table: "Candidatura",
                column: "FkIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatura_FkIdVaga",
                table: "Candidatura",
                column: "FkIdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_FkIdEmpresa",
                table: "Vaga",
                column: "FkIdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatura");

            migrationBuilder.DropTable(
                name: "Vaga");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
