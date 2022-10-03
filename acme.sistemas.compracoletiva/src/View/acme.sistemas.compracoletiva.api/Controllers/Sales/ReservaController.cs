using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.core.Dtos.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService) 
        {
            _reservaService = reservaService;
        }


        [ClaimsAuthorize("Reservar", "Add")]
        [UnitOfWorkFilter]
        [HttpPost("Reservar")]
        public IActionResult Reservar(ReservaDto reservaDto)
        {
            try
            {
                _reservaService.Reservar(reservaDto);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Reservar", "Add")]
        [UnitOfWorkFilter]
        [HttpPost]
        public async Task<IActionResult> AddAsync(Reserva reserva)
        {
            try
            {
                await _reservaService.AddAsync(reserva);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);

            }
        }

        [ClaimsAuthorize("Reservar", "Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var reservas = _reservaService.GetAll<Reserva, Reserva>();
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);

            }
        }


        [ClaimsAuthorize("Reservar", "Read")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {

                var reserva = await _reservaService.GetByIdAsync<Reserva, Reserva>(id);
                return Ok(id);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Reservar", "Update")]
        [UnitOfWorkFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Reserva reserva, Guid id)
        {
            try
            {

                _reservaService.Update(reserva);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


        [ClaimsAuthorize("Reservar", "Delete")]
        [UnitOfWorkFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var reserva = await _reservaService.GetByIdAsync<Reserva, Reserva>(id);

                _reservaService.Remove(reserva);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}


