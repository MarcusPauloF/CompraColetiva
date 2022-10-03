using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Product
{
    public class OfertaDto
    {

        public string Titulo { get;  set; }
        public string Descricao { get; set; }
        public string Condicao { get;  set; }
        public DateTime DataInicio { get;  set; }
        public DateTime DataTermino { get;  set; }
        public decimal ValorProduto { get;  set; }
        public decimal ValorComDesconto { get;  set; }
        public int QuantidadeOfertaDisponivel { get;  set; }
    }
}
