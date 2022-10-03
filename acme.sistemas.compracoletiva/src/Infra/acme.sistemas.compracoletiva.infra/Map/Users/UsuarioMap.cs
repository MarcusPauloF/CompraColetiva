using acme.sistemas.compracoletiva.domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Users

{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.Property(t => t.UserName).HasColumnName("Nome").HasMaxLength(255);
            builder.Property(t => t.TwoFactorEnabled).HasColumnName("AutenticacaoDoisFatores");
            builder.Property(t => t.AccessFailedCount).HasColumnName("QuantidadeFalhaAoAcessar");
            builder.Property(t => t.Email).HasMaxLength(255);
            builder.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmado").HasMaxLength(255);
            builder.Property(t => t.PasswordHash).HasColumnName("Senha");
            builder.Property(t => t.PhoneNumber).HasColumnName("Celular").HasMaxLength(14);
            builder.Property(t => t.PhoneNumberConfirmed).HasColumnName("CelularConfirmado");
            builder.Property(t => t.NormalizedEmail).HasColumnName("EmailNormalizado");

            builder.Property(t => t.PessoaId).HasColumnName("PessoaId");
            builder.HasOne(t => t.Pessoa).WithMany(t => t.Usuarios).HasForeignKey(t => t.PessoaId);

        }
    }
}
