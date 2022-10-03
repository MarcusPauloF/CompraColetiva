using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _tipoUsarioController;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            _tipoUsarioController = tipoUsuarioService;
        }
        
        [ClaimsAuthorize("TipoUsuario","Add")]
        [UnitOfWorkFilter]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(TipoUsuario tipoUsuario)
        {
            _tipoUsarioController.Add(tipoUsuario);

            return Ok();
        }
    }
}
