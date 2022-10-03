using acme.sistemas.compracoletiva.domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace acme.sistemas.compracoletiva.infra.Map.Users
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);


            builder.Property(_ => _.Nome).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.NomeFantasia).HasMaxLength(500);
            builder.Property(_ => _.Celular).IsRequired().HasMaxLength(20);
            builder.Property(_ => _.Telefone).HasMaxLength(20);
            builder.Property(_ => _.DataNascimento);
            builder.Property(_ => _.TipoPessoa).IsRequired();
            builder.Property(_ => _.CPF).HasMaxLength(11);
            builder.Property(_ => _.CNPJ).HasMaxLength(14);
            builder.Property(_ => _.InscricaoMunicipal).HasMaxLength(20);

            builder.HasOne(t => t.Email).WithOne(t => t.Pessoa).HasForeignKey<Pessoa>(t => t.EmailId);
        }
    }
}
