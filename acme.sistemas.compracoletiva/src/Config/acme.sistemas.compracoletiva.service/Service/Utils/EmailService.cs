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
    public class EmailService : BaseService<Email>, IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public EmailService(IEmailRepository emailRepository,
            IMapper mapper) : base(emailRepository)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }
    }
}
