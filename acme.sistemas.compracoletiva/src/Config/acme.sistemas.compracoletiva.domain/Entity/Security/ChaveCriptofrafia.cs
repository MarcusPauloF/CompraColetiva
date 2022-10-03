using System.ComponentModel.DataAnnotations.Schema;

namespace acme.sistemas.compracoletiva.domain.Entity.Security
{
    [NotMapped]
    public class ChaveCriptofrafia
    {
        public string ChavePublica { get;  set; }
        public string ChavePrivada { get; set; }

    }
}
