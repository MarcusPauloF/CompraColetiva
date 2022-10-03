using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Location;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : BaseController<Endereco>
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService) : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
    }
}
