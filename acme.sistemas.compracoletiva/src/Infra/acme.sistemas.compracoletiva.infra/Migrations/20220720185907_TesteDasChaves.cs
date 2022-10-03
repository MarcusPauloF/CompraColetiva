using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acme.sistemas.compracoletiva.infra.Migrations
{
    public partial class TesteDasChaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Notificacao_NotificacaoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NotificacaoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Produto",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "NotificacaoId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PessoaId",
                table: "Encomenda",
                newName: "UsuarioFornecedorId");

            migrationBuilder.RenameColumn(
                name: "CompraId",
                table: "Encomenda",
                newName: "UsuarioClienteId");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "ProdutoUsuario",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Pagamento",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "Comprador",
                table: "Oferta",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fornecedor",
                table: "Oferta",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "EnederecoId",
                table: "EnderecoPessoa",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "CompraProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    ProdutoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CompraId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioVendaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuarioCompraId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    UsuarioCriacaoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UsuarioModificacaoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraProduto_AspNetUsers_UsuarioCompraId",
                        column: x => x.UsuarioCompraId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraProduto_AspNetUsers_UsuarioVendaId",
                        column: x => x.UsuarioVendaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotificacaoUsuario",
                columns: table => new
                {
                    NotificacoesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsuariosId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacaoUsuario", x => new { x.NotificacoesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_NotificacaoUsuario_AspNetUsers_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificacaoUsuario_Notificacao_NotificacoesId",
                        column: x => x.NotificacoesId,
                        principalTable: "Notificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoUsuario_ProdutoId",
                table: "ProdutoUsuario",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoUsuario_UsuarioId",
                table: "ProdutoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_UsuarioId",
                table: "Pagamento",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_ProdutoId",
                table: "Encomenda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_UsuarioClienteId",
                table: "Encomenda",
                column: "UsuarioClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomenda_UsuarioFornecedorId",
                table: "Encomenda",
                column: "UsuarioFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_CompraId",
                table: "CompraProduto",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_ProdutoId",
                table: "CompraProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_UsuarioCompraId",
                table: "CompraProduto",
                column: "UsuarioCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraProduto_UsuarioVendaId",
                table: "CompraProduto",
                column: "UsuarioVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacaoUsuario_UsuariosId",
                table: "NotificacaoUsuario",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_AspNetUsers_UsuarioClienteId",
                table: "Encomenda",
                column: "UsuarioClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_AspNetUsers_UsuarioFornecedorId",
                table: "Encomenda",
                column: "UsuarioFornecedorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomenda_Produto_ProdutoId",
                table: "Encomenda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamento_AspNetUsers_UsuarioId",
                table: "Pagamento",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoUsuario_AspNetUsers_UsuarioId",
                table: "ProdutoUsuario",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoUsuario_Produto_ProdutoId",
                table: "ProdutoUsuario",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_AspNetUsers_UsuarioClienteId",
                table: "Encomenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_AspNetUsers_UsuarioFornecedorId",
                table: "Encomenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomenda_Produto_ProdutoId",
                table: "Encomenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagamento_AspNetUsers_UsuarioId",
                table: "Pagamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoUsuario_AspNetUsers_UsuarioId",
                table: "ProdutoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoUsuario_Produto_ProdutoId",
                table: "ProdutoUsuario");

            migrationBuilder.DropTable(
                name: "CompraProduto");

            migrationBuilder.DropTable(
                name: "NotificacaoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoUsuario_ProdutoId",
                table: "ProdutoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoUsuario_UsuarioId",
                table: "ProdutoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Pagamento_UsuarioId",
                table: "Pagamento");

            migrationBuilder.DropIndex(
                name: "IX_Encomenda_ProdutoId",
                table: "Encomenda");

            migrationBuilder.DropIndex(
                name: "IX_Encomenda_UsuarioClienteId",
                table: "Encomenda");

            migrationBuilder.DropIndex(
                name: "IX_Encomenda_UsuarioFornecedorId",
                table: "Encomenda");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ProdutoUsuario");

            migrationBuilder.DropColumn(
                name: "Comprador",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "Oferta");

            migrationBuilder.RenameColumn(
                name: "UsuarioFornecedorId",
                table: "Encomenda",
                newName: "PessoaId");

            migrationBuilder.RenameColumn(
                name: "UsuarioClienteId",
                table: "Encomenda",
                newName: "CompraId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Pagamento",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "EnederecoId",
                table: "EnderecoPessoa",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "Compra",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                precision: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificacaoId",
                table: "AspNetUsers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NotificacaoId",
                table: "AspNetUsers",
                column: "NotificacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Notificacao_NotificacaoId",
                table: "AspNetUsers",
                column: "NotificacaoId",
                principalTable: "Notificacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
