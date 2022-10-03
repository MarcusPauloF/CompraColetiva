using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using acme.sistemas.compracoletiva.core.Dtos.Utils;

namespace acme.sistemas.compracoletiva.service.Service.Utils
{
    public class PagamentoService : BaseService<Pagamento>, IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper mapper;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IMapper mapper) : base(pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            this.mapper = mapper;
        }

        public void RealizarPagamento(PagamentoDto pagamentoDto)
        {
            Pagamento pagamento = new Pagamento(pagamentoDto);
            pagamento.Pagar(pagamentoDto);
            _pagamentoRepository.Add(pagamento);
        }
    }
}