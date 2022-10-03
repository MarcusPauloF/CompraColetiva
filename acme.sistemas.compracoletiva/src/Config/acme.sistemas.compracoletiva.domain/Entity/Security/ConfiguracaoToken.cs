using acme.sistemas.compracoletiva.core.Base;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    public class ConfiguracaoToken : BaseEntity
    {
        public ConfiguracaoToken(){}
        public ConfiguracaoToken (string accessKey, int? expiracao)
        {
            AccessKey = accessKey;
            Expiracao = expiracao;
        }


        public string AccessKey { get;  set; }
        public int? Expiracao { get; set; }
        public virtual ICollection<ConfiguracaoTokenSistema> AutenticacoesSistemas { get;  set; }
    }
}
