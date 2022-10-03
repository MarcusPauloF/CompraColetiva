using acme.sistemas.compracoletiva.domain.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Products
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);



            builder.Property(_ => _.Nome).HasPrecision(500).IsRequired();
            builder.Property(_ => _.Valor).HasPrecision(20, 2).IsRequired();
            builder.Property(_ => _.ValorUnitario).HasPrecision(20, 2).IsRequired();
            builder.Property(_ => _.TicketMinimo).HasPrecision(20).IsRequired();
            builder.Property(_ => _.Prazo).HasPrecision(20).IsRequired();
            builder.HasOne(t => t.TipoProduto).WithMany(t => t.Produtos).HasForeignKey(t => t.TipoProdutoId);
        }
    }
}
