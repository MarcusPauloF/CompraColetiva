using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Users
{
    public class EnderecoPessoaDto
    {
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public EnderecoDto Endereco { get; set; }
    }
}
