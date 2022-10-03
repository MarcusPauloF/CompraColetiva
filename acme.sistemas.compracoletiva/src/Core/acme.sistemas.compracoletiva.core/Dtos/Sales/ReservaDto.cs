using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Sales
{
    public class ReservaDto
    {
        public Guid FornecedorUsuarioId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid ClienteUsuarioId { get; private set; }
        public DateTime Prazo { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime Expiracao { get; private set; }
    }
}
