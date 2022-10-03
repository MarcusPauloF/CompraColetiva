using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.core.Base;

namespace acme.sistemas.compracoletiva.domain.Entity.Utils
{
    public class Email : BaseEntity, IAggregateRoot
    {
        public Email(string nome)
        {
            Nome = nome;
        }

        protected Email()
        {

        }

        public string Nome { get; private set; }
        

        public virtual Pessoa Pessoa { get; private set; }
        public virtual EnvioEmail DestinatiroEmail { get; private set; }
        public virtual ICollection<EnvioEmail> EnvioEmailsCopias { get; private set; } = new HashSet<EnvioEmail>();
       
        public virtual EmailConfiguracaoEmail EmailConfiguracaoEmailEnvioEmail { get; private set; }
        public virtual EmailConfiguracaoEmail EmailConfiguracaoEmailRemetente { get; private set; }

        public void SetEnvioEmail(ICollection<EnvioEmail> envioEmails) => EnvioEmailsCopias = envioEmails;
        public void AddEnvioEmail(EnvioEmail envioEmail) => EnvioEmailsCopias.Add(envioEmail);

        public void Ataulizar(Email email)
        {
            if (this.Nome != email.Nome)
                Nome = email.Nome;

            base.Atualizar(email.UsuarioModificacaoId);
        }
    }
}
