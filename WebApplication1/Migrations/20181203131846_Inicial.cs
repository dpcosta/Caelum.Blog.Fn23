using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Resumo = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Titulo", "Resumo", "Categoria" },
                values: new object[]
                {
                    "Harry Potter III",
                    "Prisioneiro de Askaban",
                    "Filmes"
                }
            );
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Titulo", "Resumo", "Categoria" },
                values: new object[]
                {
                    "Harry Potter II",
                    "Câmara Secreta",
                    "Filmes"
                }
            );
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Titulo", "Resumo", "Categoria" },
                values: new object[]
                {
                    "Harry Potter I",
                    "Pedra Filosofal",
                    "Filmes"
                }
            );
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Titulo", "Resumo", "Categoria" },
                values: new object[]
                {
                    "Lata d'água na cabeça",
                    "Samba famoso de época",
                    "Músicas"
                }
            );
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Titulo", "Resumo", "Categoria" },
                values: new object[]
                {
                    "Game of Thrones",
                    "Winter is Coming",
                    "Séries"
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
