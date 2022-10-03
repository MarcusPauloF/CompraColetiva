using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
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
    public class EncomendaMap : IEntityTypeConfiguration<Encomenda>
    {
        public void Configure(EntityTypeBuilder<Encomenda> builder)
        {
            builder.ToTable("Encomenda");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.Property(t => t.Validade);

            builder.HasOne(t => t.UsuarioCliente).WithMany(t => t.RealizaEncomendas).HasForeignKey(t => t.UsuarioClienteId);
            builder.HasOne(t => t.UsuarioFornecedor).WithMany(t => t.ForneceEncomendas).HasForeignKey(t => t.UsuarioFornecedorId);
            builder.HasOne(t => t.Produto).WithMany(t => t.Encomendas).HasForeignKey(t => t.ProdutoId);
            
        }
    }
}
