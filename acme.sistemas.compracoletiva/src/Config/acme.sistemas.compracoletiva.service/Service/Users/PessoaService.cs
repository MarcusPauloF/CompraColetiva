using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Users
{
    public class PessoaService : BaseService<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository,
            IMapper mapper) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }
    }
}
