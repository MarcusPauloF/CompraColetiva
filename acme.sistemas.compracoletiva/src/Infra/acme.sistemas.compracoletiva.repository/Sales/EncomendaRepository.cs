using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using acme.sistemas.compracoletiva.infra.Config;
using acme.sistemas.compracoletiva.repository;

namespace acme.sistemas.compracoletiva.repository.Sales
{
    public class EncomendaRepository : BaseRepository<Encomenda>, IEncomendaRepository
    {
        public EncomendaRepository(Context db) : base(db)
        {
        }
    }
}
