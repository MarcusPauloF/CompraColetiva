using acme.sistemas.compracoletiva.core.Dtos.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;

namespace acme.sistemas.compracoletiva.service.Interfaces.Service.Utils
{
    public interface IPagamentoService : IBaseService<Pagamento>
    {
        void RealizarPagamento(PagamentoDto pagamentoDto);
    }
}
