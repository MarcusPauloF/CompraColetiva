using acme.sistemas.compracoletiva.service.Interfaces;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Service.Utils
{
    public class SeguroService : BaseService<Seguro>, ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;

        public SeguroService(ISeguroRepository seguroRepository) : base(seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }
    }
}
