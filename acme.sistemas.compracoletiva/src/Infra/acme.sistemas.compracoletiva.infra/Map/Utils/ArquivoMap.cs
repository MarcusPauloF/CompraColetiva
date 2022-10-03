using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Utils
{
    public class ArquivoMap : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.ToTable("Arquivo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.Property(_ => _.NomeExibicao).IsRequired();
            builder.Property(_ => _.NomeSalvo).IsRequired();
            builder.Property(_ => _.Caminho).IsRequired();
            builder.Property(_ => _.Extensao).IsRequired();
            builder.Property(_ => _.Hash).IsRequired();
        }
    }
}
