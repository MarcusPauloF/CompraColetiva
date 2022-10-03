using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.config.Security
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string nomeClaim, string valorClaim) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] {new Claim(nomeClaim,valorClaim) };
        }
    }
}
