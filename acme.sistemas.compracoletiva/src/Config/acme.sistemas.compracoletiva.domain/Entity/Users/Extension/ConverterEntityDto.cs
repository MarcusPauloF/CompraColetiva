using acme.sistemas.compracoletiva.core.Dtos.Users;
using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Entity.Utils;

namespace acme.sistemas.compracoletiva.core.Helpers
{
    public static class ConverterEntityDto
    {
        public static PessoaDto ParaPessoaDto(this Pessoa pessoa)
        {
            PessoaDto pessoaDto = new PessoaDto()
            {
                Celular = pessoa.Celular,
                CNPJ = pessoa.CNPJ,
                CPF = pessoa.CPF,
                DataNascimento = pessoa.DataNascimento,
                Email = pessoa.Email.Nome,
                EnderecoPessoas = pessoa.EnderecoPessoas.ParaEnderecosPessoasDto(),
                InscricaoMunicipal = pessoa.InscricaoMunicipal,
                Nome = pessoa.Nome,
                NomeFantasia = pessoa.NomeFantasia,
                Telefone = pessoa.Telefone,
                TipoPessoa = pessoa.TipoPessoa

            };
            return pessoaDto;
        }

        public static Pessoa ParaPessoa(this PessoaDto pessoa)
        {
            Pessoa pessoaDto = new Pessoa(
                celular: pessoa.Celular,
                cnpj: pessoa.CNPJ,
                cpf: pessoa.CPF,
                dataNascimento: pessoa.DataNascimento,
                inscricaoMunicipal: pessoa.InscricaoMunicipal,
                nome: pessoa.Nome,
                nomeFantasia: pessoa.NomeFantasia,
                telefone: pessoa.Telefone,
                tipoPessoa: pessoa.TipoPessoa
            );
            pessoaDto.SetEnderecoPessoas(pessoa.EnderecoPessoas.ParaEnderecosPessoas());
            pessoaDto.SetEmail(new Email(pessoa.Email));
            return pessoaDto;
        }

        public static EnderecoPessoaDto ParaEnderecoPessoaDto(this EnderecoPessoa enderecoPessoa)
        {
            EnderecoPessoaDto enderecoPes = new EnderecoPessoaDto()
            {
                Complemento = enderecoPessoa.Complemento,
                Endereco = enderecoPessoa.Endereco.ParaEnderecoDto(),
                Latitude = enderecoPessoa.Latitude,
                Longitude = enderecoPessoa.Longitude,
                Numero = enderecoPessoa.Numero
            };
            return enderecoPes;
        }
        public static EnderecoPessoa ParaEnderecoPessoa(this EnderecoPessoaDto enderecoPessoa)
        {

            EnderecoPessoa enderecoPes = new EnderecoPessoa(enderecoPessoa.Numero, enderecoPessoa.Complemento, enderecoPessoa.Latitude, enderecoPessoa.Longitude);
            
            return enderecoPes;
        }

        public static List<EnderecoPessoaDto> ParaEnderecosPessoasDto(this ICollection<EnderecoPessoa> enderecosPessoas)
        {
            List<EnderecoPessoaDto> enderecoPessoaDtos = new List<EnderecoPessoaDto>();
            foreach (var enderecoPessoa in enderecosPessoas)
            {
                enderecoPessoaDtos.Add(enderecoPessoa.ParaEnderecoPessoaDto());
            }
            return enderecoPessoaDtos;
        }
        public static List<EnderecoPessoa> ParaEnderecosPessoas(this List<EnderecoPessoaDto> enderecosPessoas)
        {
            List<EnderecoPessoa> enderecoPessoaDtos = new List<EnderecoPessoa>();
            foreach (var enderecoPessoa in enderecosPessoas)
            {
                enderecoPessoaDtos.Add(enderecoPessoa.ParaEnderecoPessoa());
            }
            return enderecoPessoaDtos;
        }

        public static EnderecoDto ParaEnderecoDto(this Endereco endereco)
        {
            EnderecoDto end = new EnderecoDto()
            {
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Pais = endereco.Pais,
                Rua = endereco.Rua
            };
            return end;
        }
        public static Endereco ParaEndereco(this EnderecoDto endereco)
        {
            Endereco end = new Endereco(endereco.Cep, endereco.Pais, endereco.Estado, endereco.Cidade, endereco.Bairro, endereco.Rua);
            
            return end;
        }

    }
}
