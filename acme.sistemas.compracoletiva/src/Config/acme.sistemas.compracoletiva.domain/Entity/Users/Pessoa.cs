using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using acme.sistemas.compracoletiva.core.Enuns;

namespace acme.sistemas.compracoletiva.domain.Entity.Users
{
    public class Pessoa : BaseEntity, IAggregateRoot
    {
        protected Pessoa() { }
        public Pessoa(string nome, string nomeFantasia, string celular, string telefone, DateTime? dataNascimento, EnumTipoPessoa tipoPessoa, string cpf, string cnpj, string inscricaoMunicipal)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Celular = celular;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            TipoPessoa = tipoPessoa;
            CPF = cpf;
            CNPJ = cnpj;
            InscricaoMunicipal = inscricaoMunicipal;
        }

        public Pessoa(string nome, string celular, string telefone, string cpf, DateTime? dataNascimento = null)
            : this(nome, null, celular, telefone, dataNascimento, EnumTipoPessoa.Fisica, cpf, null, null)
        {
        }

        public Pessoa(string nome, string nomeFantasia,  string celular, string telefone, string cnpj,
            string inscricaoMunicipal, DateTime? dataNascimento = null)
            : this(nome, nomeFantasia, celular, telefone, dataNascimento, EnumTipoPessoa.Juridica, null, cnpj, inscricaoMunicipal)
        {
        }

        public string Nome { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Celular { get; private set; }
        public string Telefone { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public string InscricaoMunicipal { get; private set; }
        public Guid EmailId { get; private set; }

        public virtual Email Email { get; private set; }


        public virtual ICollection<Usuario> Usuarios { get; private set; }
        public virtual ICollection<EnderecoPessoa> EnderecoPessoas { get; private set; } = new HashSet<EnderecoPessoa>();

        public void SetEnderecoPessoas(ICollection<EnderecoPessoa> enderecosPessoas) =>
            EnderecoPessoas = enderecosPessoas;
        public void SetEmailId(Guid emailId) => EmailId = emailId;
        public void SetEmail(Email email) => Email = email;

        public void AddEnderecoPessoa(EnderecoPessoa enderecosPessoa) =>
            EnderecoPessoas.Add(enderecosPessoa);
        

        public void Atualizar(Pessoa pessoa)
        {
            if (this.Nome != pessoa.Nome)
                Nome = pessoa.Nome;

            if (this.NomeFantasia != pessoa.NomeFantasia)
                NomeFantasia = pessoa.NomeFantasia;

            if (this.Celular != pessoa.Celular)
                Celular = pessoa.Celular;

            if (this.Telefone != pessoa.Telefone)
                Telefone = pessoa.Telefone;

            if (this.DataNascimento != pessoa.DataNascimento)
                DataNascimento = pessoa.DataNascimento;

            if (this.TipoPessoa != pessoa.TipoPessoa)
                TipoPessoa = pessoa.TipoPessoa;

            if (this.Celular != pessoa.Celular)
                Celular = pessoa.Celular;

            if (this.EmailId != pessoa.EmailId)
                EmailId = pessoa.EmailId;


            base.Atualizar(pessoa.UsuarioModificacaoId);
        }

        public void AtualizarCPF(string cpf, Guid usuarioModificacaoId)
        {
            if (this.CPF != cpf)
                CPF = cpf;

            base.Atualizar(usuarioModificacaoId);
        }

        public void AtualizarCNPJ(string cnpj, Guid usuarioModificacaoId)
        {
            if(this.CNPJ != cnpj)
                CNPJ = cnpj;

            base.Atualizar(usuarioModificacaoId);
        }

    }
}
