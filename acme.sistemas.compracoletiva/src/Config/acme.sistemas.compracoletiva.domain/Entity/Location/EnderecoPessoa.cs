using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.core.Base;
using System;

namespace acme.sistemas.compracoletiva.domain.Entity.Location
{
    public class EnderecoPessoa : BaseEntity, IAggregateRoot
    {
        public EnderecoPessoa(int numero, string complemento, string latitude, string longitude)
        {
            Numero = numero;
            Complemento = complemento;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Numero { get; private set; }
        public string Complemento { get; private set; }

        public string Latitude { get; private set; }
        public string Longitude{ get; private set; }

        public Guid PessoaId{ get; private set; }
        public Guid EnederecoId { get; private set; }
        
        public Pessoa Pessoa { get; private set; }
        public Endereco Endereco { get; private set; }

        public void CriarEnderecoPessoa(Guid pessoaId, Endereco endereco)
        {
            PessoaId = pessoaId;
            Endereco = endereco;
        }
        public void CriarEnderecoNovaPessoa(Endereco endereco)
        {
            Endereco = endereco;
        }
        public void VincularEnderecoPessoa(Guid enederecoId, Guid pessoaId)
        {
            PessoaId = pessoaId;
            EnederecoId = enederecoId;
        }
        public void VincularEnderecoNovaPessoa(Guid enederecoId)
        {
            EnederecoId = enederecoId;
        }
        public void Atualizar(EnderecoPessoa enderecoPessoa)
        {
            if(this.Numero != enderecoPessoa.Numero)
                Numero = enderecoPessoa.Numero;

            if (this.Complemento != enderecoPessoa.Complemento)
                Complemento = enderecoPessoa.Complemento;

            if (this.Latitude != enderecoPessoa.Latitude)
                Latitude = enderecoPessoa.Latitude;

            if (this.Longitude != enderecoPessoa.Longitude)
                Longitude = enderecoPessoa.Longitude;

            if (this.PessoaId != enderecoPessoa.PessoaId)
                PessoaId = enderecoPessoa.PessoaId;

            if (this.EnederecoId != enderecoPessoa.EnederecoId)
                VincularEnderecoNovaPessoa(enderecoPessoa.EnederecoId);


            base.Atualizar(enderecoPessoa.UsuarioModificacaoId);
        }

    }
}
