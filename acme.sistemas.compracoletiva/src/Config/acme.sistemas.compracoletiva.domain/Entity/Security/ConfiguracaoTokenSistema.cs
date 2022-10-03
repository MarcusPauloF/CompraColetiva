using acme.sistemas.compracoletiva.core.Base;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    public class ConfiguracaoTokenSistema : BaseEntity
    {
        public ConfiguracaoTokenSistema(string sistemaEmissao, string validoEm)
        {
            SistemaEmissao = sistemaEmissao;
            ValidoEm = validoEm;
        }

        public string SistemaEmissao { get; private set; }
        public string ValidoEm { get; private set; }

        public Guid AutenticacaoId { get; private set; }
        public virtual ConfiguracaoToken Autorizacao { get; private set; }

    }
}
