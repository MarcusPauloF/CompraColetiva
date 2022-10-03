using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoUsuarioController : BaseController<ProdutoUsuario>
    {
        private readonly IProdutoUsuarioService _produtoUsuarioService;

        public ProdutoUsuarioController(IProdutoUsuarioService produtoUsuarioService) : base(produtoUsuarioService)
        {
            _produtoUsuarioService = produtoUsuarioService;
        }
    }
}
