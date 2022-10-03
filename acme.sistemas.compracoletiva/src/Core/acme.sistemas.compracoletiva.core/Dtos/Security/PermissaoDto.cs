using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Security
{
    public class PermissaoDto
    {
        public string Nome { get; set; }
        public List<ClaimDto> Claims { get; set; }  
    }
}
