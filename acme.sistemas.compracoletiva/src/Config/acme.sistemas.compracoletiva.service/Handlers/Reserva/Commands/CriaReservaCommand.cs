using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Handlers.Reserva.Commands
{
    public class CriaReservaCommand
    {
        public DateTime Prazo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Expiracao { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid ClienteUsuarioId { get; set; }
        public Guid FornecedorUsuarioId { get; set; }
    }
}
