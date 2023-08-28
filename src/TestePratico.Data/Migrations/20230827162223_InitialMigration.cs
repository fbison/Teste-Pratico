using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestePratico.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", nullable: false),
                    Login = table.Column<string>(type: "varchar(64)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(256)", nullable: false),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(64)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
