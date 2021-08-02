using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechStyle.dominio.Migrations
{
    public partial class InicialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_segmento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "varchar(100)", nullable: false),
                    Subcategoria = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_segmento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_venda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDeVenda = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    SKU = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdSegmento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_produto_tbl_segmento_IdSegmento",
                        column: x => x.IdSegmento,
                        principalTable: "tbl_segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_detalhe_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tamanho = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_detalhe_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_detalhe_produto_tbl_produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "tbl_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeTotal = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", nullable: false),
                    QuantidadeAtual = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_estoque_tbl_produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "tbl_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_item_venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_item_venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_item_venda_tbl_produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "tbl_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_item_venda_tbl_venda_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "tbl_venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_loja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_loja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_loja_tbl_produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "tbl_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_detalhe_produto_IdProduto",
                table: "tbl_detalhe_produto",
                column: "IdProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_estoque_IdProduto",
                table: "tbl_estoque",
                column: "IdProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_item_venda_IdProduto",
                table: "tbl_item_venda",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_item_venda_IdVenda",
                table: "tbl_item_venda",
                column: "IdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_loja_IdProduto",
                table: "tbl_loja",
                column: "IdProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_produto_IdSegmento",
                table: "tbl_produto",
                column: "IdSegmento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_detalhe_produto");

            migrationBuilder.DropTable(
                name: "tbl_estoque");

            migrationBuilder.DropTable(
                name: "tbl_item_venda");

            migrationBuilder.DropTable(
                name: "tbl_loja");

            migrationBuilder.DropTable(
                name: "tbl_venda");

            migrationBuilder.DropTable(
                name: "tbl_produto");

            migrationBuilder.DropTable(
                name: "tbl_segmento");
        }
    }
}
