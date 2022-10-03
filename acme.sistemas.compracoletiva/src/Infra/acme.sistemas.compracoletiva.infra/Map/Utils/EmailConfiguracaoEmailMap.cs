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
    public class EmailConfiguracaoEmailMap : IEntityTypeConfiguration<EmailConfiguracaoEmail>
    {
        public void Configure(EntityTypeBuilder<EmailConfiguracaoEmail> builder)
        {
            builder.ToTable("EmailConfiguracaoEmail");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.Senha);

            builder.HasOne(t => t.ConfiguracaoEmail).WithMany(t => t.EmailConfiguracaoEmail).HasForeignKey(t => t.ConfiguracaoEmailId);
            builder.HasOne(t => t.EmailRemetente).WithOne(t=>t.EmailConfiguracaoEmailRemetente).HasForeignKey<EmailConfiguracaoEmail>(t => t.EmailRemetenteId);
            builder.HasOne(t => t.EmailEnvio).WithOne(t => t.EmailConfiguracaoEmailEnvioEmail).HasForeignKey<EmailConfiguracaoEmail>(t => t.EmailEnvioId);
        }
    }
}
