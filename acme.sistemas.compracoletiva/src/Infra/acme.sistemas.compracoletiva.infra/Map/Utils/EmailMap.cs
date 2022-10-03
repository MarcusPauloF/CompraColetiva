using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Utils
{
    public class EmailMap : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("Email");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.HasMany(t => t.EnvioEmailsCopias).WithMany(t => t.EmailsCopias).UsingEntity<Dictionary<string, object>>("EmailCopias",
                t =>
                {
                    t.Property<Guid>("Id");
                    t.HasKey("Id");
                    t.Property<Guid>("EmailId");
                    t.Property<Guid>("EnvioEmailId");

                    t.HasOne<Email>().WithMany().HasForeignKey("EmailId");
                    t.HasOne<EnvioEmail>().WithMany().HasForeignKey("EnvioEmailId");
                }
               );
        }
    }
}
