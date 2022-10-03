using acme.sistemas.compracoletiva.service.Interfaces.Service.Package;
using acme.sistemas.compracoletiva.domain.Entity.Package;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Package;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Package
{
    public class PacoteService : BaseService<Pacote>, IPacoteService
    {
        private readonly IPacoteRepository _pacoteRepository;
        private readonly IMapper _mapper;

        public PacoteService(IPacoteRepository produtoRepository,
            IMapper mapper) : base (produtoRepository)
        {
            _pacoteRepository = produtoRepository;
        }
    }
}
