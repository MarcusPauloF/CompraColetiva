using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Utils
{
    public class ConfiguracaoEmail: BaseEntity, IAggregateRoot
    {
        public string ConfigSet { get; private set; }
        public string Host { get; private set; }
        public int Porta { get; private set; }
        public bool Ssl { get; private set; }
        public virtual ICollection<EmailConfiguracaoEmail> EmailConfiguracaoEmail { get; private set; }

        public void Atualizar(ConfiguracaoEmail configuracaoEmail)
        {
            if(this.ConfigSet != configuracaoEmail.ConfigSet)
                ConfigSet = configuracaoEmail.ConfigSet;

            if (this.Host != configuracaoEmail.Host)
                Host = configuracaoEmail.Host;

            if (this.Porta != configuracaoEmail.Porta)
                Porta = configuracaoEmail.Porta;

            if (this.Ssl != configuracaoEmail.Ssl)
                Ssl = configuracaoEmail.Ssl;

            base.Atualizar(configuracaoEmail.UsuarioModificacaoId);
        }
    }
}
