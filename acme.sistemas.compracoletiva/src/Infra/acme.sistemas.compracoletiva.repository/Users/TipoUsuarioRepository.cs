using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using acme.sistemas.compracoletiva.infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Users
{
    public class TipoUsuarioRepository : BaseRepository<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(Context db) : base(db)
        {
        }
    }
}
