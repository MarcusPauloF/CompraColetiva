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
    public class EnvioEmailMap : IEntityTypeConfiguration<EnvioEmail>
    {
        public void Configure(EntityTypeBuilder<EnvioEmail> builder)
        {
            builder.ToTable("EnvioEmail");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.Titulo).HasMaxLength(100);
            builder.Property(t => t.Corpo).HasMaxLength(500);

            builder.HasOne(t => t.Destinatario).WithOne(t => t.DestinatiroEmail).HasForeignKey<EnvioEmail>(t => t.DestinatarioId);
        }
    }
}
