using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Service.Utils
{
    public class EnvioEmailService : BaseService<EnvioEmail>, IEnvioEmailService
    {
        private readonly IEnvioEmailRepository _envioEmailRepository;
        private readonly IMapper _mapper;

        public EnvioEmailService(IEnvioEmailRepository envioEmailRepository,
            IMapper mapper) : base(envioEmailRepository)
        {
            _envioEmailRepository = envioEmailRepository;
            _mapper = mapper;
        }
    }
}
