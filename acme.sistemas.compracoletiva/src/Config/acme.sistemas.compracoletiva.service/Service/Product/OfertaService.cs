using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.core.Dtos.Product;

namespace acme.sistemas.compracoletiva.service.Service.Product
{
    public class OfertaService : BaseService<Oferta>, IOfertaService
    {
        private readonly IOfertaRepository _ofertaRepository;
        private readonly IMapper _mapper;

        public OfertaService(IOfertaRepository ofertaRepository, IMapper mapper) : base(ofertaRepository)
        {
            _ofertaRepository = ofertaRepository;
            _mapper = mapper;
        }


        public void Ofertar(OfertaDto ofertaDto)
        {
            Oferta oferta = new Oferta();
            oferta.Ofertar( ofertaDto);
            _ofertaRepository.Add(oferta);
        }
    }
}
