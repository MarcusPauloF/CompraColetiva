using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProdutoController : BaseController<TipoProduto>
    {
        private readonly ITipoProdutoService _tipoProdutoService;

        public TipoProdutoController(ITipoProdutoService tipoProdutoService) : base(tipoProdutoService)
        {
            _tipoProdutoService = tipoProdutoService;
        }
    }
}
