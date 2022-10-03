using acme.sistemas.compracoletiva.service.Interfaces.Service.Location;
using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Location;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Location
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }
    }
}
