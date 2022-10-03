using acme.sistemas.compracoletiva.domain.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.infra.Map.Products
{
    public class ProdutoUsuarioMap : IEntityTypeConfiguration<ProdutoUsuario>
    {
        public void Configure(EntityTypeBuilder<ProdutoUsuario> builder)
        {
            builder.ToTable("ProdutoUsuario");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.Nome).IsRequired().HasMaxLength(500);
            builder.Property(t => t.ProdutoId).IsRequired();
            builder.Property(t => t.Prazo).IsRequired();
        }
    }
}
