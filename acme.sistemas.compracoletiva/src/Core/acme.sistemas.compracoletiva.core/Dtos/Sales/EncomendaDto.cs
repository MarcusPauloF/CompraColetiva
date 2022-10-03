using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Sales
{
    public class EncomendaDto
    {
        public Guid UsuarioFornecedorId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid UsuarioClienteId { get; private set; }
    }
}
