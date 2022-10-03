using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Sales
{
    public class CompraProduto : BaseEntity, IAggregateRoot
    {
        public CompraProduto(decimal valorUnitario, decimal quantidade)
        {
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

        protected CompraProduto() { }
        

        public decimal ValorUnitario { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorTotal { get => ValorUnitario * Quantidade;}


        public Guid ProdutoId { get; private set; }
        public Guid CompraId { get; private set; }
        public Guid UsuarioVendaId { get; private set; }
        public Guid UsuarioCompraId { get; private set; }


        public Produto Produto { get; private set; }
        public Compra Compra { get; private set; }
        public Usuario UsuarioVenda { get; private set; }
        public Usuario UsuarioCompra { get; private set; }



        public void Comprar(Reserva reserva)
        {
            ProdutoId = reserva.ProdutoId;
            ValorUnitario = reserva.Produto.ValorUnitario;
            Quantidade = reserva.Quantidade;
            UsuarioCompraId = reserva.ClienteUsuarioId;
            UsuarioVendaId = reserva.FornecedorUsuarioId;
            Compra = new Compra(Quantidade, ValorTotal);
        }

        public void Atualizar(CompraProduto compraProduto)
        {
            if(this.ValorUnitario != compraProduto.ValorUnitario)
                ValorUnitario = compraProduto.ValorUnitario;

            if (this.Quantidade != compraProduto.Quantidade)
                Quantidade = compraProduto.Quantidade;

        if (this.ProdutoId != compraProduto.ProdutoId)
                ProdutoId = compraProduto.ProdutoId;

            if (this.CompraId != compraProduto.CompraId)
                CompraId = compraProduto.CompraId;

            if (this.UsuarioVendaId != compraProduto.UsuarioVendaId)
                UsuarioVendaId = compraProduto.UsuarioVendaId;

            if (this.UsuarioCompraId != compraProduto.UsuarioCompraId)
                UsuarioCompraId = compraProduto.UsuarioCompraId;

            base.Atualizar(compraProduto.UsuarioModificacaoId);
        }
    }
}
