using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Product;
using acme.sistemas.compracoletiva.infra.Config;

namespace acme.sistemas.compracoletiva.repository.Product
{
    public class TipoProdutoRepository : BaseRepository<TipoProduto>, ITipoProdutoRepository
    {
        public TipoProdutoRepository(Context db) : base(db)
        {

        }
    }
}
