using acme.sistemas.compracoletiva.core.Dtos.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Service.Sales
{
    public class ReservaService : BaseService<Reserva>, IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly IMapper mapper;

        public ReservaService(IReservaRepository reservaRepository, IMapper mapper) : base(reservaRepository)
        {
            _reservaRepository = reservaRepository;
            this.mapper = mapper;
        }

        public void Reservar(ReservaDto reservaDto)
        {
            Reserva reserva = new Reserva(reservaDto.Prazo, reservaDto.Quantidade, reservaDto.Expiracao);
            reserva.ReservarProduto(reservaDto);
            _reservaRepository.Add(reserva);
        }
    }
}
