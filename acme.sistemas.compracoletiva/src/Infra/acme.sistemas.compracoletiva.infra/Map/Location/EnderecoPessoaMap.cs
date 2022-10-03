using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace acme.sistemas.compracoletiva.infra.Map.Location
{
    public class EnderecoPessoaMap : IEntityTypeConfiguration<EnderecoPessoa>
    {
        public void Configure(EntityTypeBuilder<EnderecoPessoa> builder)
        {
            builder.ToTable("EnderecoPessoa");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.Property(t => t.Numero);
            builder.Property(t => t.Complemento);

            builder.HasOne(t => t.Endereco).WithMany(t => t.EnderecoPessoas).HasForeignKey(t => t.EnederecoId);
            builder.HasOne(t => t.Pessoa).WithMany(t => t.EnderecoPessoas).HasForeignKey(t => t.PessoaId);

        }
    }
}
