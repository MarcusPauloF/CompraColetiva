using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using acme.sistemas.compracoletiva.infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Users
{
    public class UsuarioRepository :  IUsuarioRepository
    {
        private readonly Context _db;
        public UsuarioRepository(Context db) 
        {
            _db = db;
        }
        public Task<IQueryable<Usuario>> GetUsuariosJoinPessoaEndereco()
        {
            IQueryable<Usuario> usuarios = (from usrs in _db.Users
                                            join prmUsrs in _db.UserRoles on usrs.Id equals prmUsrs.UserId
                                            join prm in _db.Roles on prmUsrs.RoleId equals prm.Id
                                            join p in _db.Pessoas on usrs.PessoaId equals p.Id
                                            join endPessoa in _db.EnderecosPessoa on p.Id equals endPessoa.PessoaId
                                            join end in _db.Enderecos on endPessoa.EnederecoId equals end.Id
                                            select usrs).Include(t => t.Pessoa).ThenInclude(t => t.EnderecoPessoas).ThenInclude(t => t.Endereco).AsNoTracking().AsQueryable();
            return Task.FromResult(usuarios);
        }
        public async Task<Usuario> GetUsuariosJoinPessoaEnderecoJoinPermissaoByLogin(string login)
        {
            Usuario usuarios = await (from usrs in _db.Users
                                      join prmUsrs in _db.UserRoles on usrs.Id equals prmUsrs.UserId
                                      join prm in _db.Roles on prmUsrs.RoleId equals prm.Id
                                      join p in _db.Pessoas on usrs.PessoaId equals p.Id
                                      join endPessoa in _db.EnderecosPessoa on p.Id equals endPessoa.PessoaId
                                      join end in _db.Enderecos on endPessoa.EnederecoId equals end.Id
                                      where usrs.Email == login
                                      select usrs).Include(t => t.Pessoa).ThenInclude(t => t.EnderecoPessoas).ThenInclude(t => t.Endereco).AsNoTracking().FirstOrDefaultAsync();
            return usuarios;
        }

    }
}
