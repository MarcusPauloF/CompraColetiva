using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Location;
using acme.sistemas.compracoletiva.infra.Config;

namespace acme.sistemas.compracoletiva.repository.Location
{
    public class EnderecoPessoaRepository : BaseRepository<EnderecoPessoa>, IEnderecoPessoaRepository
    {
        public EnderecoPessoaRepository(Context db) : base(db)
        {
        }
    }
}
