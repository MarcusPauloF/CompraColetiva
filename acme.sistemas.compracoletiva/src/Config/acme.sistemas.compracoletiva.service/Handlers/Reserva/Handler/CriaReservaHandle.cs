using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.service.Handlers.Reserva.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Handlers.Reserva.Handler
{
    public class CriaReservaHandle
    {
        private readonly IReservaRepository _reservaRepository;

        public CriaReservaHandle(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        /*public async Task Handle(CriaReservaCommand criaReservaCommand)
        {
            domain.Entity.Sales.Reserva reserva = new domain.Entity.Sales.Reserva(criaReservaCommand.Prazo, criaReservaCommand.Quantidade, criaReservaCommand.Expiracao);
            reserva.ReservarProduto(criaReservaCommand.ProdutoId, criaReservaCommand.ClienteUsuarioId, criaReservaCommand.FornecedorUsuarioId);
            await _reservaRepository.AddAsync(reserva);
        }*/
    }
}
