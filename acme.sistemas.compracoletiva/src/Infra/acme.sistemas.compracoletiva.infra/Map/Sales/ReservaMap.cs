using acme.sistemas.compracoletiva.domain.Entity.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.infra.Map.Sales
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataCriacao).IsRequired();
            builder.Property(t => t.DataModificacao).IsRequired()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            builder.Property(t => t.UsuarioCriacaoId);
            builder.Property(t => t.UsuarioModificacaoId);
            builder.Property(t => t.Ativo).HasDefaultValue(true);

            builder.Property(t => t.Prazo).IsRequired();
            builder.Property(t => t.Quantidade).HasPrecision(20).IsRequired();
            builder.Property(t => t.Expiracao).IsRequired();
            builder.HasOne(t => t.ForncedorUsuario).WithMany(t => t.ReservasFornecedores).HasForeignKey(t => t.FornecedorUsuarioId);
            builder.HasOne(t => t.ClienteUsuario).WithMany(t => t.ReservasClientes).HasForeignKey(t => t.ClienteUsuarioId);
            builder.HasOne(t => t.Produto).WithMany(t => t.ListaDeReserva).HasForeignKey(t => t.ProdutoId);
        }
    }
}
