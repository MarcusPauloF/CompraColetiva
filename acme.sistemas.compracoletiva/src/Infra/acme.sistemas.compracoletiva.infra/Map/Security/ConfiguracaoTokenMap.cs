using acme.sistemas.compracoletiva.domain.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EProcessos.Infra.Mappings.Security
{
    internal class ConfiguracaoTokenMap : IEntityTypeConfiguration<ConfiguracaoToken>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoToken> builder)
        {
            builder.ToTable("ConfiguracaoToken");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.AccessKey).HasMaxLength(1000).IsRequired();
            builder.Property(t => t.Expiracao).HasDefaultValue(2);

        }
    }
}
