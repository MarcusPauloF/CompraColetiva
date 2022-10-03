using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.service.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [UnitOfWorkFilter]
        [HttpPost]
        public virtual async Task<IActionResult> AddAsync(TEntity baseService)
        {
            try
            {
                await _baseService.AddAsync(baseService);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [UnitOfWorkFilter]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Remove(TEntity entity)
        {

            try
            {
                _baseService.Remove(entity);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [UnitOfWorkFilter]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, TEntity entity)
        {
            try
            {
                _baseService.Update(entity);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e); 
            }
        }

        
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
               
                
              var objeto = await  _baseService.GetAllAsync<TEntity, TEntity>();
                return Ok(objeto);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
