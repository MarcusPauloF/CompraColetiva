using Microsoft.AspNetCore.Identity;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    public class PermissaoUsuario : IdentityUserRole<Guid>
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }
        public bool Ativo { get; private set; }
        public Guid? UsuarioCriacaoId { get; private set; }
        public Guid? UsuarioModificacaoId { get; private set; }

        public bool Add { get; private set; }
        public bool Update { get; private set; }
        public bool Delete { get; private set; }
        public bool Read { get; private set; }
    }
}
