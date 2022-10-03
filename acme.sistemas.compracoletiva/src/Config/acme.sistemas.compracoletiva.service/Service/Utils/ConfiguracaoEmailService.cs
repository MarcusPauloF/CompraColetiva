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
    public class ConfiguracaoEmailService : BaseService<ConfiguracaoEmail>,IConfiguracaoEmailService
    {
        private readonly IConfiguracaoEmailRepository _configuracaoEmailRepository;
        private readonly IMapper _mapper;

        public ConfiguracaoEmailService(IConfiguracaoEmailRepository configuracaoEmailRepository,
            IMapper mapper) : base(configuracaoEmailRepository)
        {
            _configuracaoEmailRepository = configuracaoEmailRepository;
            _mapper = mapper;
        }
    }
}
