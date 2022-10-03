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
    public class EmailConfiguracaoEmailService : BaseService<EmailConfiguracaoEmail>, IEmailConfiguracaoEmailService
    {
        private readonly IEmailConfiguracaoEmailRepository _emailConfiguracaoEmailRepository;
        private readonly IMapper _mapper;


        public EmailConfiguracaoEmailService(IEmailConfiguracaoEmailRepository emailConfiguracaoEmailRepository,
            IMapper mapper) : base (emailConfiguracaoEmailRepository)
        {
            _emailConfiguracaoEmailRepository = emailConfiguracaoEmailRepository;
            _mapper = mapper;
        }
    }
}
