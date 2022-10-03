using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.infra.Config;

namespace acme.sistemas.compracoletiva.repository.Utils
{
    public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(Context db) : base(db)
        {
        }
    }
}
