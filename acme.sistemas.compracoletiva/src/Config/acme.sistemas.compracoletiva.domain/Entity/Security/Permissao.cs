using Microsoft.AspNetCore.Identity;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    public class Permissao : IdentityRole<Guid>
    {
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }
        public bool Ativo { get; private set; }
        public Guid? UsuarioCriacaoId { get; private set; }
        public Guid? UsuarioModificacaoId { get; private set; }

        public Permissao() { }
        public Permissao(string name)
        {
            this.Name = name;
        }

    }
}
