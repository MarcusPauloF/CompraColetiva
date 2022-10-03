using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Sales
{
    public class CompraService : BaseService<Compra>, ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IMapper _mapper;

        public CompraService(ICompraRepository compraRepository,
            IMapper mapper) : base(compraRepository)
        {
            _compraRepository = compraRepository;
            _mapper = mapper;
        }
    }
}
