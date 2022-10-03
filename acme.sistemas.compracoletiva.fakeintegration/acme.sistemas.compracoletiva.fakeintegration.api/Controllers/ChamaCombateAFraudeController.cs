using acme.sistemas.compracoletiva.fakeintegration.api.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace acme.sistemas.compracoletiva.fakeintegration.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamaCombateAFraudeController : ControllerBase
    {
        [HttpPost("Autenticar")]
        public object Post(
          [FromServices] SigningConfigurations signingConfigurations,
          [FromServices] TokenConfigurations tokenConfigurations)
        {

            PayloadCombateFraude cf = new PayloadCombateFraude();
            if (true)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity("" + cf.ISS, "Autorizacao"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, ""+cf.ISS)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = cf.ISS,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha na autenticacao"
                };
            }
        }
    }
}
