
using acme.sistemas.compracoletiva.core.Base;
using System.Collections.Generic;

namespace acme.sistemas.compracoletiva.domain.Entity.Location
{
    public class Endereco : BaseEntity, IAggregateRoot
    {
        protected Endereco()
        {
        }

        public  Endereco(string cep, string pais, string estado, string cidade, string bairro, string rua)
        {
            Cep = cep;
            Pais = pais;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
        }

        public string Cep { get; private set; }
        public string Pais { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public virtual ICollection<EnderecoPessoa> EnderecoPessoas { get; private set; } = new HashSet<EnderecoPessoa>();


        public void Atualizar(Endereco endereco)
        {
            if (this.Cep != endereco.Cep)
                Cep = endereco.Cep;

            if (this.Pais != endereco.Pais)
                Pais = endereco.Pais;

            if (this.Estado != endereco.Estado)
                Estado = endereco.Estado;

            if (this.Cidade != endereco.Cidade)
                Cidade = endereco.Cidade;

            if (this.Bairro != endereco.Bairro)
                Bairro = endereco.Bairro;

            if (this.Rua != endereco.Rua)
                Rua = endereco.Rua;

            base.Atualizar(endereco.UsuarioModificacaoId);
        }
    }
}
