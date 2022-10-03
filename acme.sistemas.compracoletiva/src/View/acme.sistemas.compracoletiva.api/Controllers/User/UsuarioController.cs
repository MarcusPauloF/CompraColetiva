using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.core.Dtos.Users;
using acme.sistemas.compracoletiva.core.Helpers;
using acme.sistemas.compracoletiva.domain.Entity.Security;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace acme.sistemas.compracoletiva.api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly RoleManager<Permissao> _permissaoManager;

        public UsuarioController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager,
            IUsuarioService usuarioService, RoleManager<Permissao> permissaoManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _usuarioService = usuarioService;
            _permissaoManager = permissaoManager;
        }


        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar(RegistroUsuarioDto registroUsuario,
                [FromHeader] string privateKey,
                 [FromServices] SigningConfigurations signingConfigurations,
                    [FromServices] ConfiguracaoToken tokenConfigurations)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _usuarioService.Cadastrar(registroUsuario, privateKey);

            if (result.Succeeded)
                return Ok(await GerarWebToken(registroUsuario.Email, privateKey, signingConfigurations, tokenConfigurations));
            else
                return BadRequest(result.Errors);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Logar(LoginUsuarioDto loginUsuario,
                        [FromHeader] string privateKey,
                         [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] ConfiguracaoToken tokenConfigurations)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Senha, true, true);

            if (result.Succeeded)
            {
                object jwt = await GerarWebToken(loginUsuario.Email, privateKey, signingConfigurations, tokenConfigurations);
                return Ok(jwt);
            }

            return BadRequest("Usuario ou senha invalidos!");
        }

        [HttpPost]
        public async Task<object> GerarWebToken(
            string email,
            [FromHeader] string privateKey,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] ConfiguracaoToken tokenConfigurations)
        {
            bool credenciaisValidas = false;
            bool chaveValida = false;

            Usuario usuario = await _usuarioService.GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(email);
            credenciaisValidas = (usuario is not null &&
                   usuario.Id == usuario.Id);

            if (usuario is not null)
            {
                try
                {
                    CriptografiaAssincrona criptografiaAssincrona = new CriptografiaAssincrona();
                    string valorCriptografado = criptografiaAssincrona.Criptografar(tokenConfigurations.AccessKey, usuario.Email);
                    string valorDescriptografado = criptografiaAssincrona.Descriptofrafar(privateKey, valorCriptografado);
                    chaveValida = usuario.Email == valorDescriptografado;
                }
                catch { chaveValida = false; }
            }
            if (credenciaisValidas && chaveValida)
            {
                var permissoes = new List<Claim>();
                var claims = await _userManager.GetClaimsAsync(usuario);
                foreach (var claim in claims)
                {
                    permissoes.Add(claim);
                }
                claims.Add(new Claim("Permissoes", JsonConvert.SerializeObject(permissoes, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")));
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString()));
                claims.Add(new Claim("Servico", JsonConvert.SerializeObject(usuario, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })));

                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity("" + usuario.Id, "Autorizacao"),
                    claims
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = (dataCriacao +
                    TimeSpan.FromHours(tokenConfigurations.Expiracao.Value));

                string urlAtual = "https://" + HttpContext.Request.Host.Value;
                var issuer = tokenConfigurations.AutenticacoesSistemas.Where(t => t.ValidoEm.Equals(urlAtual)).Select(t => t.SistemaEmissao).FirstOrDefault();
                var audience = tokenConfigurations.AutenticacoesSistemas.Where(t => t.ValidoEm.Equals(urlAtual)).Select(t => t.ValidoEm).FirstOrDefault();

                if (issuer is null || audience is null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha na autenticação 2"
                    };
                }

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Audience = audience,
                    Expires = dataExpiracao,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao
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
                    message = "Falha na autenticacao 3"
                };
            }
        }

        [HttpGet("GetUsuariosJoinPessoaEndereco")]
        [ClaimsAuthorize("Usuario", "Read")]
        //[EnableQuery]
        public Task<IQueryable<Usuario>> GetUsuariosJoinPessoaEndereco()
        {
            return _usuarioService.GetUsuariosJoinPessoaEndereco();
        }

        //[HttpGet]
        //[ClaimsAuthorize("Usuario", "Read")]
        ////[EnableQuery]
        //public async Task<IQueryable<Usuario>> Get()
        //{
        //    return await _usuarioService.GetAllAsync<Usuario,Usuario>();
        //}

    }
}
