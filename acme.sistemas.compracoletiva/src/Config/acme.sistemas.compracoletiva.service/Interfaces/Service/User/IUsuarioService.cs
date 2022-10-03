using acme.sistemas.compracoletiva.domain.Entity.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.core.Dtos.Users;

namespace acme.sistemas.compracoletiva.service.Interfaces.Service.User
{
    public interface IUsuarioService
    {
        Task<IdentityResult> Cadastrar(RegistroUsuarioDto registroUsuario, string privateKey);
        Task<IQueryable<Usuario>> GetUsuariosJoinPessoaEndereco();
        Task<Usuario> GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(string login);

    }
}
