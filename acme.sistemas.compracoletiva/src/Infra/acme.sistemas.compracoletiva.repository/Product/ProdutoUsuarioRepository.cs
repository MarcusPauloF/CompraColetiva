using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Product;
using acme.sistemas.compracoletiva.infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Product
{
    public class ProdutoUsuarioRepository : BaseRepository<ProdutoUsuario>, IProdutoUsuarioRepository
    {
        public ProdutoUsuarioRepository(Context db) : base(db)
        {
        }
    }
}
