using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.repository.Utils
{
    public class ParametroRepository : BaseRepository<Parametro>, IParametroRepository
    {
        public ParametroRepository(Context db) : base(db)
        {
        }

        public async Task<Parametro> GetParametroByNome(string nome)
        {
            var parametro = await _db.Parametros.FirstOrDefaultAsync(p => p.Nome == nome);
            return parametro;
        }

        public  async Task<IEnumerable<Parametro>> GetAllParametro()
        {
            return await _db.Parametros.ToListAsync();
        }
    }
}
