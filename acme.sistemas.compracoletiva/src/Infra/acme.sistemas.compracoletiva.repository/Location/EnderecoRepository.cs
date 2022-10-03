using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Location;
using acme.sistemas.compracoletiva.infra.Config;

namespace acme.sistemas.compracoletiva.repository.Location
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(Context db) : base(db)
        {
        }
    }
}
