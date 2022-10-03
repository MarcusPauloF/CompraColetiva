using acme.sistemas.compracoletiva.core.Dtos.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Dtos.Users
{
    public class RegistroUsuarioDto
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage="O campo {0} esta em formato errado")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres",MinimumLength =9)]
        public string Senha { get; set; }
        [Compare("Senha",ErrorMessage = "As senhas não comferem")]
        public string ConfirmacaoSenha { get; set; }
        
        public Guid TipoUsuarioId { get; set; }
        public PessoaDto Pessoa { get; set; }
        public PermissaoDto Permissao { get; set; }
        public List<ClaimDto> Claim { get; set; }
    }
}
