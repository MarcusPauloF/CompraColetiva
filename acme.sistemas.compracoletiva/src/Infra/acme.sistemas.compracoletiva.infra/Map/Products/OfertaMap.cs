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
    public class OfertaMap : IEntityTypeConfiguration<Oferta>
    {
        public void Configure(EntityTypeBuilder<Oferta> builder)
        {
            builder.ToTable("Oferta");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);



           
            builder.Property(t => t.Titulo).HasMaxLength(300).IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(t => t.Condicao).HasMaxLength(300).IsRequired();
            builder.Property(t => t.PalavraChavePesquisa).HasMaxLength(150).IsRequired();
            builder.Property(t => t.DataInicio).IsRequired();
            builder.Property(t => t.DataTermino).IsRequired();
            builder.Property(t => t.ValorProduto).IsRequired().HasPrecision(20,2);
            builder.Property(t => t.ValorComDesconto).IsRequired().HasPrecision(20,2);
            builder.Property(t => t.QuantidadeOfertaDisponivel).IsRequired();
            builder.HasOne(t => t.Usuario).WithMany(t => t.Ofertas).HasForeignKey(t => t.UsuarioId);
        }
    }
}
