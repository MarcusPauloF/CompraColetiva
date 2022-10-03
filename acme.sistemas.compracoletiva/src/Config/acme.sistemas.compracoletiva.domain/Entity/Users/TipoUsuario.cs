using acme.sistemas.compracoletiva.core.Base;
using System.Collections.Generic;

namespace acme.sistemas.compracoletiva.domain.Entity.Users
{
    public class TipoUsuario : BaseEntity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public virtual ICollection<Usuario> Usuarios { get; private set; } = new HashSet<Usuario>();

        protected TipoUsuario() { }

        public TipoUsuario(string nome) : base()
        {
            Nome = nome;
        }

        public void Atualizar(TipoUsuario tipoUsuario)
        {
            if(this.Nome != tipoUsuario.Nome)
                Nome = tipoUsuario.Nome;

            base.Atualizar(tipoUsuario.UsuarioModificacaoId);
        }
    }
}
