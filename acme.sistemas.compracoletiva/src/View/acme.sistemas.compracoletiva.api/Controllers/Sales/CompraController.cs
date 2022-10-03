using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : BaseController<Compra>
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService) : base(compraService)
        {
            _compraService = compraService;
        }
    }
}
