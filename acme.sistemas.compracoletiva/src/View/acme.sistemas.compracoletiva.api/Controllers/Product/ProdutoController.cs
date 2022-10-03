using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController<Produto>
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService) : base(produtoService)
        {
            _produtoService = produtoService;
        }
    }
}
