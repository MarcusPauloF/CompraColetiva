using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Service.Sales
{
    public class UnidadeMedidaCompraService : BaseService<UnidadeMedidaCompra>, IUnidadeMedidaCompraService
    {
        private readonly IUnidadeMedidaCompraRepository _unidadeMedidaCompraRepository;
        private readonly IMapper _mapper;

        public UnidadeMedidaCompraService(IUnidadeMedidaCompraRepository unidadeMedidaCompraRepository, IMapper mapper) : base(unidadeMedidaCompraRepository)
        {
            _unidadeMedidaCompraRepository = unidadeMedidaCompraRepository;
            _mapper = mapper;
        }
    }
}
