using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using acme.sistemas.compracoletiva.core.Dtos.Users;
using acme.sistemas.compracoletiva.core.Helpers;

namespace acme.sistemas.compracoletiva.service.Service.Users
{
    public class UsuarioService :  IUsuarioService
    {
        private readonly IUsuarioRepository _baseRepository;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository baseRepository,
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            IMapper mapper) 
        {
            _baseRepository = baseRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Cadastrar(RegistroUsuarioDto registroUsuario, string privateKey)
        {
            Usuario userIdentity = new Usuario(registroUsuario.Pessoa.ParaPessoa())
            {
                UserName = registroUsuario.Email,
                Email = registroUsuario.Email,
                EmailConfirmed = true,
                TipoUsuarioId = registroUsuario.TipoUsuarioId
            };
            IdentityResult result = null;
            try
            {
                result = await _userManager.CreateAsync(userIdentity, registroUsuario.Senha);

                if (!result.Succeeded)
                    return result;
            }
            catch (Exception e)
            {

            }

            try
            {
                var resultPermissao = await _userManager.AddToRoleAsync(userIdentity, registroUsuario.Permissao.Nome);
                if (resultPermissao.Succeeded)
                {
                    foreach (var t in registroUsuario.Claim)
                    {
                        var resultado = await _userManager.AddClaimAsync(userIdentity, new Claim(t.Nome, t.Valor.Replace("All", "Read,Add,Update,Delete")));
                        if (!resultado.Succeeded)
                            return resultado;
                    }

                    await _signInManager.SignInAsync(userIdentity, false);
                    return result;
                }
                else
                    return resultPermissao;
            }
            catch (Exception e)
            {
                return result;

            }
        }
        public async Task<IQueryable<Usuario>> GetUsuariosJoinPessoaEndereco()
        {
            return await _baseRepository.GetUsuariosJoinPessoaEndereco();
        }

        public Task<Usuario> GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(string login)
        {
            return _baseRepository.GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(login);
        }


    }
}
