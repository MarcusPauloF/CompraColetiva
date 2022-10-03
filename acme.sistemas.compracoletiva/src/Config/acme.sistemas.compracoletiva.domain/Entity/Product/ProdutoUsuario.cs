using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Product
{
    public class ProdutoUsuario : BaseEntity, IAggregateRoot
    {
        protected ProdutoUsuario()
        {

        }

        public string Nome { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid UsuarioId { get; private set; }

        public DateTime Prazo { get; private set; }
        public Produto Produto { get; private set; }
        public Usuario Usuario { get; private set; }


        public void Atualizar(ProdutoUsuario produtoUsuario)
        {
            if (this.Nome != produtoUsuario.Nome)
                Nome = produtoUsuario.Nome;

            if (this.ProdutoId != produtoUsuario.ProdutoId)
                ProdutoId = produtoUsuario.ProdutoId;

            if (this.UsuarioId != produtoUsuario.UsuarioId)
                UsuarioId = produtoUsuario.UsuarioId;

            if (this.Prazo != produtoUsuario.Prazo)
                Prazo = produtoUsuario.Prazo;

            base.Atualizar(produtoUsuario.UsuarioModificacaoId);
        }
    }
}
