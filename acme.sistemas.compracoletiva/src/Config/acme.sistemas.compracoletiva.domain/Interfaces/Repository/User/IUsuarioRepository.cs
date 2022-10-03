using acme.sistemas.compracoletiva.domain.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Interfaces.Repository.User
{
    public interface IUsuarioRepository 
    {
        Task<IQueryable<Usuario>> GetUsuariosJoinPessoaEndereco();
        Task<Usuario> GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(string login);
    }
}
