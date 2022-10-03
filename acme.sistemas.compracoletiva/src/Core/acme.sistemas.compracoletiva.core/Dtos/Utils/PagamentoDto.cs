using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Utils
{
    public class PagamentoDto
    {
        public DateTime DataPagamento { get;  set; }
        public decimal ValorRecebido { get;  set; }
        public string NomePagador { get;  set; }
        public decimal ValorAReceber { get;  set; }
        public DateTime DataVencimento { get;  set; }
        public Guid? UsuarioId { get;  set; }
        public DateTime DataEmQueDinheiroCaiNaConta { get; set; }
        public DateTime DataPrevistaPagamento { get; set; }
    }
}
