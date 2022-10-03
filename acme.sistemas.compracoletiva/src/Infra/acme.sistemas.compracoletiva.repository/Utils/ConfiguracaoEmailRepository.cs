using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Utils
{
    public class ConfiguracaoEmailRepository : BaseRepository<ConfiguracaoEmail>, IConfiguracaoEmailRepository
    {
        public ConfiguracaoEmailRepository(Context db) : base(db)
        {
        }
    }
}
