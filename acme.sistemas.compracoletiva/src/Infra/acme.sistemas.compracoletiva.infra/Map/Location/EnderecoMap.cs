using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Location
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);



            builder.Property(t => t.Cep).HasMaxLength(15).IsRequired();
            builder.HasIndex(t => t.Cep).IsUnique(true);
            builder.Property(t => t.Pais).HasMaxLength(300).IsRequired();
            builder.Property(t => t.Estado).HasMaxLength(230);
            builder.Property(t => t.Cidade).HasMaxLength(230).IsRequired();
            builder.Property(t => t.Bairro).HasMaxLength(230).IsRequired();
            builder.Property(t => t.Rua).HasMaxLength(230).IsRequired();


        }
    }
}
