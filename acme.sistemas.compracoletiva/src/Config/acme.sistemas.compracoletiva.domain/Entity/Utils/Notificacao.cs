using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Utils
{
    public class Notificacao : BaseEntity, IAggregateRoot
    {
        protected Notificacao()
        {

        }

        public Notificacao(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Notificacao(Guid id, DateTime dataCriacao, bool ativo, Guid? usuarioCriacaoId, Guid? usuarioModificacaoId, string key, string value)
            : base(id, dataCriacao, ativo, usuarioCriacaoId, usuarioModificacaoId)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public virtual ICollection<Usuario> Usuarios { get; private set; } = new HashSet<Usuario>();


        public void SetUsuarios(ICollection<Usuario> usuarios) => Usuarios = usuarios;
        public void AddUsuario(Usuario usuario) => Usuarios.Add(usuario);
    }
}
