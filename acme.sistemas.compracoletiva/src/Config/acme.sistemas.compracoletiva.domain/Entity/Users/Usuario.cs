using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.core.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.domain.Entity.Sales;

namespace acme.sistemas.compracoletiva.domain.Entity.Users
{
    public class Usuario : IdentityUser<Guid>, IAggregateRoot
    {
        
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }
        public bool Ativo { get; private set; }
        public Guid? UsuarioCriacaoId { get; private set; }
        public Guid? UsuarioModificacaoId { get; private set; }

        public Guid PessoaId { get; private set; }
        public Guid TipoUsuarioId { get;  set; }

        public virtual Pessoa Pessoa { get; private set; }
        public virtual TipoUsuario TipoUsuario { get; private set; }

        public virtual ICollection<Oferta> Ofertas { get; private set; } = new HashSet<Oferta>();
        public virtual ICollection<Reserva> ReservasClientes { get; private set; } = new HashSet<Reserva>();
        public virtual ICollection<ProdutoUsuario> ProdutoUsuarios { get; private set; } = new HashSet<ProdutoUsuario>();
        public virtual ICollection<CompraProduto> UsuariosVendas { get; private set; } = new HashSet<CompraProduto>();
        public virtual ICollection<CompraProduto> UsuariosCompras { get; private set; } = new HashSet<CompraProduto>();
        public virtual ICollection<Pagamento> Pagamentos { get; private set; } = new HashSet<Pagamento>();
        public virtual ICollection<Notificacao> Notificacoes { get; private set; } = new HashSet<Notificacao>();
        public virtual ICollection<Encomenda> RealizaEncomendas { get; private set; } = new HashSet<Encomenda>();
        public virtual ICollection<Encomenda> ForneceEncomendas { get; private set; } = new HashSet<Encomenda>();
        public virtual ICollection<Reserva> ReservasFornecedores { get; private set; } = new HashSet<Reserva>();
        
        
        protected Usuario() { }

        public Usuario(Pessoa pessoa) : base()
        {
            Pessoa = pessoa;
        }

        public Usuario(Pessoa pessoa, TipoUsuario tipoUsuario) : this(pessoa)
        {
            TipoUsuario = tipoUsuario;
        }

        public Usuario(Pessoa pessoa, Guid tipoUsuarioId) : this(pessoa)
        {
            TipoUsuarioId = tipoUsuarioId;
        }
    }
}
