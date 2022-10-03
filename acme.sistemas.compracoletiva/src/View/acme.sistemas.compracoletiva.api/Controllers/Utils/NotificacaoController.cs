using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace acme.sistemas.compracoletiva.api.Controllers.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : BaseController<Notificacao>
    {
        private readonly INotificacaoService _notificacao;

        public NotificacaoController(INotificacaoService notificacao) : base(notificacao)
        {
            _notificacao = notificacao;
        }
    }
}
