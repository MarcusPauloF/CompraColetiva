using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Handlers.Reserva.Querys
{
    public class ReservaQuery
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeProduto { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFornecedor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Expiracao { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid FornecedorId { get; set; }

    }
}
