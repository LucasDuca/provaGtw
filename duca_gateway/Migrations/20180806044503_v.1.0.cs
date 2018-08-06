using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace duca_gateway.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lojista",
                columns: table => new
                {
                    id_lojista = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    razaosocial = table.Column<string>(type: "varchar(100)", nullable: false),
                    login = table.Column<string>(type: "varchar(10)", nullable: false),
                    senha = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lojista", x => x.id_lojista);
                });

            migrationBuilder.CreateTable(
                name: "configuracao",
                columns: table => new
                {
                    id_configuracao = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_lojista = table.Column<int>(type: "int(11)", nullable: false),
                    stone = table.Column<string>(type: "char(1)", nullable: false),
                    cielo = table.Column<string>(type: "char(1)", nullable: false),
                    antifraude = table.Column<string>(type: "char(1)", nullable: false),
                    rule_visa = table.Column<string>(type: "char(1)", nullable: true),
                    rule_master = table.Column<string>(type: "char(1)", nullable: true),
                    stonekey = table.Column<string>(type: "varchar(45)", nullable: true),
                    cielokey = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracao", x => x.id_configuracao);
                    table.ForeignKey(
                        name: "FK_LOJISTA",
                        column: x => x.id_lojista,
                        principalTable: "lojista",
                        principalColumn: "id_lojista",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transacao",
                columns: table => new
                {
                    id_transacao = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_lojista = table.Column<int>(type: "int(11)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(2000)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    cielo = table.Column<string>(type: "char(1)", nullable: true),
                    stone = table.Column<string>(type: "char(1)", nullable: true),
                    visa = table.Column<string>(type: "char(1)", nullable: true),
                    master = table.Column<string>(type: "char(1)", nullable: true),
                    credit_card = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacao", x => x.id_transacao);
                    table.ForeignKey(
                        name: "fk_id_loja",
                        column: x => x.id_lojista,
                        principalTable: "lojista",
                        principalColumn: "id_lojista",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_LOJISTA_idx",
                table: "configuracao",
                column: "id_lojista");

            migrationBuilder.CreateIndex(
                name: "fk_id_loja_idx",
                table: "transacao",
                column: "id_lojista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracao");

            migrationBuilder.DropTable(
                name: "transacao");

            migrationBuilder.DropTable(
                name: "lojista");
        }
    }
}
