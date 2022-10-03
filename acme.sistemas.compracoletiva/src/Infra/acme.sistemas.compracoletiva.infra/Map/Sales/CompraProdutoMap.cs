using acme.sistemas.compracoletiva.domain.Entity.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.infra.Map.Sales
{
    public class CompraProdutoMap : IEntityTypeConfiguration<CompraProduto>
    {
        public void Configure(EntityTypeBuilder<CompraProduto> builder)
        {
            builder.ToTable("CompraProduto");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.ValorUnitario).IsRequired();
            builder.Property(t => t.Quantidade).IsRequired();
            builder.Property(t => t.ValorTotal).IsRequired();

            builder.HasOne(t => t.Produto).WithMany(t => t.CompraProdutos).HasForeignKey(t => t.ProdutoId);
            builder.HasOne(t => t.Compra).WithMany(t => t.CompraProduto).HasForeignKey(t => t.CompraId);
            builder.HasOne(t => t.UsuarioVenda).WithMany(t => t.UsuariosVendas).HasForeignKey(t => t.UsuarioVendaId);
            builder.HasOne(t => t.UsuarioCompra).WithMany(t => t.UsuariosCompras).HasForeignKey(t => t.UsuarioCompraId);
        }
    }
}
