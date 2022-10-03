using Microsoft.AspNetCore.Identity;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public Guid Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }
        public bool Ativo { get; private set; }
        public Guid? UsuarioCriacaoId { get; private set; }
        public Guid? UsuarioModificacaoId { get; private set; }
    }
}
