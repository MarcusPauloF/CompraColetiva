using acme.sistemas.compracoletiva.domain.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EProcessos.Infra.Mappings.Security
{
    internal class ConfiguracaoTokenSistemaMap : IEntityTypeConfiguration<ConfiguracaoTokenSistema>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoTokenSistema> builder)
        {
            builder.ToTable("ConfiguracaoTokenSistema");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.SistemaEmissao).IsRequired();
            builder.Property(t => t.ValidoEm).HasDefaultValue(2);

            builder.HasOne(t => t.Autorizacao).WithMany(t => t.AutenticacoesSistemas).HasForeignKey(t => t.AutenticacaoId);
        }
    }
}
