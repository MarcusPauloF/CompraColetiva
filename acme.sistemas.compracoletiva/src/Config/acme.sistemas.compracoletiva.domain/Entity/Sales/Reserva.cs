using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.core.Dtos.Sales;

namespace acme.sistemas.compracoletiva.domain.Entity.Sales
{
    public class Reserva : BaseEntity, IAggregateRoot
    {
        protected Reserva()
        {

        }
        public Reserva(DateTime prazo, int quantidade, DateTime expiracao)
        {
            Prazo = prazo;
            Quantidade = quantidade;
            Expiracao = expiracao;
        }


        public DateTime Prazo { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime Expiracao { get; private set; }
        public Guid FornecedorUsuarioId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid ClienteUsuarioId { get; private set; }

        public virtual Usuario ForncedorUsuario { get; private set; }
        public virtual Produto Produto { get; private set; }
        public virtual Usuario ClienteUsuario { get; private set; }

        public void Atualizar(Reserva reserva)
        {
            if (this.Prazo != reserva.Prazo)
                Prazo = reserva.Prazo;
            if(this.Expiracao != reserva.Expiracao)
                Expiracao = reserva.Expiracao;
            if(this.Quantidade != reserva.Quantidade)
                Quantidade = reserva.Quantidade;
            if(this.ClienteUsuarioId != reserva.ClienteUsuarioId)
                ClienteUsuarioId = reserva.ClienteUsuarioId;
            if(this.FornecedorUsuarioId != reserva.FornecedorUsuarioId)
                FornecedorUsuarioId= reserva.FornecedorUsuarioId;
            if(this.ProdutoId != reserva.ProdutoId)
                ProdutoId = reserva.ProdutoId;

            base.Atualizar(reserva.UsuarioModificacaoId);
        }
        public void ReservarProduto(ReservaDto reservaDto)
        {
            ProdutoId = reservaDto.ProdutoId;
            ClienteUsuarioId = reservaDto.ClienteUsuarioId;
            FornecedorUsuarioId = reservaDto.FornecedorUsuarioId;
        }
    }
    
}
