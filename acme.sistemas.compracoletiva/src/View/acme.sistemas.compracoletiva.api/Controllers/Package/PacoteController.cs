using acme.sistemas.compracoletiva.domain.Entity.Package;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Package;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Package
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : BaseController<Pacote>
    {
        private readonly IPacoteService _pacoteService;

        public PacoteController(IPacoteService pacoteService) : base(pacoteService)
        {
            _pacoteService = pacoteService;
        }
    }
}
