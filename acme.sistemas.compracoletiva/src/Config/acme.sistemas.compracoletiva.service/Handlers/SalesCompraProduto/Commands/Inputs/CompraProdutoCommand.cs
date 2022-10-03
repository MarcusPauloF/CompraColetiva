using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Handlers.SalesCompraProduto.Commands.Inputs
{
    public class CompraProdutoCommand
    {
        public decimal ValorUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorTotal { get => ValorUnitario * Quantidade; set { } }


        public Guid ProdutoId { get; set; }
        public Guid CompraId { get; set; }
        public Guid UsuarioVendaId { get; set; }
        public Guid UsuarioCompraId { get; set; }
    }
}
