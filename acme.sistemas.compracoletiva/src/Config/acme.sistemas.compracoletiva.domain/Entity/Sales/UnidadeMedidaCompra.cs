using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Sales
{
    public class UnidadeMedidaCompra : BaseEntity, IAggregateRoot
    {
        protected UnidadeMedidaCompra()
        {

        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }



        public void Atualizar(UnidadeMedidaCompra unidadeMedidaCompra)
        {
            if(this.Nome != unidadeMedidaCompra.Nome)
                Nome = unidadeMedidaCompra.Nome;

            if (this.Descricao != unidadeMedidaCompra.Descricao)
                Descricao = unidadeMedidaCompra.Descricao;

            base.Atualizar(unidadeMedidaCompra.UsuarioModificacaoId);
        }

    }
}
