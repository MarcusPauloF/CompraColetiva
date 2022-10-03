using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaCompraController : BaseController<UnidadeMedidaCompra>
    {
        private readonly IUnidadeMedidaCompraService _unidadeMedidaCompraService;

        public UnidadeMedidaCompraController(IUnidadeMedidaCompraService unidadeMedidaCompraService) : base(unidadeMedidaCompraService)
        {
            _unidadeMedidaCompraService = unidadeMedidaCompraService;
        }
    }
}
