using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using acme.sistemas.compracoletiva.infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Sales
{
    public class UnidadeMedidaCompraRepository : BaseRepository<UnidadeMedidaCompra>, IUnidadeMedidaCompraRepository
    {
        public UnidadeMedidaCompraRepository(Context db) : base(db)
        {
        }
    }
}
