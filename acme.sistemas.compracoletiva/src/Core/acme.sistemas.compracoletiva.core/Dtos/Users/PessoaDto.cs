using acme.sistemas.compracoletiva.core.Enuns;

namespace acme.sistemas.compracoletiva.core.Dtos.Users
{
    public class PessoaDto
    {
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public EnumTipoPessoa TipoPessoa { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoMunicipal { get; set; }

        public List<EnderecoPessoaDto> EnderecoPessoas { get; set; }

    }
}
