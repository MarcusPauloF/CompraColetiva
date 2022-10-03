using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.core.Dtos.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService) 
        {
            _pagamentoService = pagamentoService;
        }


        [ClaimsAuthorize("Pagamento", "Add")]
        [UnitOfWorkFilter]
        [HttpPost("Pagar")]
        public IActionResult Pagar(PagamentoDto pagamentoDto)
        {
            try
            {
                _pagamentoService.RealizarPagamento(pagamentoDto);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Pagamento", "Add")]
        [UnitOfWorkFilter]
        [HttpPost]
        public  async Task<IActionResult> AddAsync(Pagamento pagamento)
        {
            try
            {
                await _pagamentoService.AddAsync(pagamento);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Pagamento", "Read")]
        [HttpGet]
        public  async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var pagamentos = await _pagamentoService.GetAllAsync<Pagamento, Pagamento>();
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Pagamento", "Read")]
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {

                var pagamento = await _pagamentoService.GetByIdAsync<Pagamento, Pagamento>(id);
                return Ok(id);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Pagamento", "Update")]
        [UnitOfWorkFilter]
        [HttpPut("{id}")]
        public  IActionResult Update(Pagamento pagamento, Guid id)
        {
            try
            {
                pagamento.Id = id;

                _pagamentoService.Update(pagamento);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [ClaimsAuthorize("Pagamento", "Delete")]
        [UnitOfWorkFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var pagamento = await _pagamentoService.GetByIdAsync<Pagamento, Pagamento>(id);

                _pagamentoService.Remove(pagamento);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
