using System.ComponentModel.DataAnnotations.Schema;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    [NotMapped]
    public class TokenConfigurations
    {
        public string Audience { get; private set; }
        public string Issuer { get; private set; }
        public int Seconds { get; private set; }
    }
}
