using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.infra.Map.Utils
{
    internal class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.DataPagamento).IsRequired();
            builder.Property(t => t.DataEmQueDinheiroCaiNaConta).IsRequired();
            builder.Property(t => t.NomePagador).IsRequired().HasMaxLength(500);
            builder.Property(t => t.ValorRecebido).IsRequired();
            builder.Property(t => t.ValorAReceber).IsRequired();
            builder.Property(t => t.DataPrevistaPagamento).IsRequired();
            builder.Property(t => t.DataVencimento).IsRequired();

            builder.HasOne(t => t.Usuario).WithMany(t => t.Pagamentos).HasForeignKey(t => t.UsuarioId);

        }
    }
}
