using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using AutoMapper;
using acme.sistemas.compracoletiva.core.Dtos.Sales;

namespace acme.sistemas.compracoletiva.service.Service.Sales
{
    public class EncomendaService : BaseService<Encomenda>, IEncomendaService
    {
        private readonly IEncomendaRepository _encomendaRepository;
        private readonly IMapper _mapper;


        public EncomendaService(IEncomendaRepository encomendaRepository,
            IMapper mapper) : base(encomendaRepository)
        {
            _encomendaRepository = encomendaRepository;
            _mapper = mapper;
        }

        public void Encomendar(EncomendaDto encomendaDto)
        {
            Encomenda encomenda = new Encomenda(encomendaDto);
            encomenda.Encomendar(encomendaDto);
            _encomendaRepository.Add(encomenda);
        }
    }
}
