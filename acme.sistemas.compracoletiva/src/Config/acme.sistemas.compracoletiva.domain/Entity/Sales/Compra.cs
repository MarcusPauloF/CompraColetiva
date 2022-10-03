using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Sales
{
    public class Compra : BaseEntity, IAggregateRoot
    {
        protected Compra() { }

        public Compra(decimal quantitdade, decimal valor)
        {
            Quantidade = quantitdade;
            Valor = valor;
        }

        public decimal Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public virtual ICollection<CompraProduto> CompraProduto { get; private set; } = new HashSet<CompraProduto>();

        public void Atualizar(Compra compra)
        {
            if (this.Quantidade != compra.Quantidade)
                Quantidade = compra.Quantidade;

            if (this.Valor != compra.Valor)
                Valor = compra.Valor;

            base.Atualizar(compra.UsuarioModificacaoId);
        }
    }
}
