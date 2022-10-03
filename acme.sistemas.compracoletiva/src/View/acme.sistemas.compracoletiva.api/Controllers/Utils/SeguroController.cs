using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : BaseController<Seguro>
    {
        private readonly ISeguroService _seguroService;

        public SeguroController(ISeguroService seguroService) : base(seguroService)
        {
            _seguroService = seguroService;
        }
    }
}
