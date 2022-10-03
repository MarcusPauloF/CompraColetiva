using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.core.Dtos.Product;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaService _ofertaService;

        public OfertaController(IOfertaService ofertaService)
        {
            _ofertaService = ofertaService;
        }


        [ClaimsAuthorize("Oferta", "Add")]
        [UnitOfWorkFilter]
        [HttpPost("Ofertar")]
        public  IActionResult Ofertar(OfertaDto ofertaDto)
        {
            try
            {
                _ofertaService.Ofertar(ofertaDto);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


        [ClaimsAuthorize("Oferta", "Add")]
        [UnitOfWorkFilter]
        [HttpPost("Pagar")]
        [HttpPost]
        public  async Task<IActionResult> AddAsync(Oferta oferta)
        {
            try
            {
                await _ofertaService.AddAsync(oferta);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Oferta", "Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var ofertas = _ofertaService.GetAll<Oferta, Oferta>();
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }


        [ClaimsAuthorize("Oferta", "Read")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {

                var oferta = await _ofertaService.GetByIdAsync<Oferta, Oferta>(id);
                return Ok(id);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Oferta", "Update")]
        [UnitOfWorkFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Oferta oferta, Guid id)
        {
            try
            {

                _ofertaService.Update(oferta);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Oferta", "Delete")]
        [UnitOfWorkFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var oferta = await _ofertaService.GetByIdAsync<Oferta, Oferta>(id);

                _ofertaService.Remove(oferta);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
