using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.core.Dtos.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Sales
{   
    public class Encomenda : BaseEntity, IAggregateRoot
    {
        protected Encomenda()
        {

        }

        public Encomenda(EncomendaDto encomendaDto)
        {
            UsuarioClienteId = encomendaDto.UsuarioClienteId;
            ProdutoId = encomendaDto.ProdutoId;
        }

        public Guid UsuarioClienteId { get; private set; }
        public Guid UsuarioFornecedorId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public DateTime Validade { get; private set; }

        public virtual Usuario UsuarioCliente { get; private set; }
        public virtual Usuario UsuarioFornecedor { get; private set; }
        public virtual Produto Produto { get; private set; }

        public void Atualizar(Encomenda encomenda)
        {
            if (this.UsuarioClienteId != encomenda.UsuarioClienteId)
                UsuarioClienteId = encomenda.UsuarioClienteId;

            if (this.UsuarioFornecedorId != encomenda.UsuarioFornecedorId)
                UsuarioFornecedorId = encomenda.UsuarioFornecedorId;

            if (this.ProdutoId != encomenda.ProdutoId)
                ProdutoId = this.ProdutoId;

            if (this.Validade != encomenda.Validade)
                Validade = encomenda.Validade;

            base.Atualizar(encomenda.UsuarioModificacaoId);
        }

        public void Encomendar(EncomendaDto encomendaDto)
        {
            UsuarioFornecedorId = encomendaDto.UsuarioFornecedorId;
            ProdutoId = encomendaDto.ProdutoId;
        }
    }
}
