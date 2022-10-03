using acme.sistemas.compracoletiva.core.Dtos.Product;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.site.Controllers.Product
{
    public class OfertaController : Controller
    {

        public IActionResult Index()
        {

            return View(
                new List<OfertaDto>() { 
                    new OfertaDto() {Condicao="1",DataInicio= DateTime.Now,DataTermino=DateTime.Now.AddDays(3),Descricao = "Detalhes Oferta Teste",QuantidadeOfertaDisponivel=100,Titulo="Oferta Teste",ValorComDesconto=20.55M, ValorProduto=50.00M },
                    new OfertaDto() {Condicao="2",DataInicio= DateTime.Now,DataTermino=DateTime.Now.AddDays(3),Descricao = "Detalhes Oferta Teste 2",QuantidadeOfertaDisponivel=100,Titulo="Oferta Teste 2",ValorComDesconto=25M, ValorProduto=55.00M }
            });
        }
    }
}
