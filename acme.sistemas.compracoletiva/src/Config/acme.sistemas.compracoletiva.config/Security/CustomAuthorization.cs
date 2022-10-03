using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.config.Security
{
    public  class CustomAuthorization
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string nomeClaim, string valorClaim)
        {
            return context.User.Identity.IsAuthenticated && context.User.Claims.Any(t => t.Type == nomeClaim && t.Value.Split(',').Contains(valorClaim));
        }
    }
}
