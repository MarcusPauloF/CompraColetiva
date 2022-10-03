using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Utils
{
    public class ConfiguracaoEmailMap : IEntityTypeConfiguration<ConfiguracaoEmail>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoEmail> builder)
        {
            builder.ToTable("ConfiguracaoEmail");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.Host).HasMaxLength(100);
            builder.Property(t => t.Porta).HasPrecision(10);
            builder.Property(t => t.Ssl);
            builder.Property(t => t.ConfigSet).HasMaxLength(100);

        }
    }
}
