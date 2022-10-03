using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace acme.sistemas.compracoletiva.core.Base
{
    [NotMapped]
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public bool Ativo { get; set; }
        public Guid? UsuarioCriacaoId { get; set; }
        public Guid? UsuarioModificacaoId { get; set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        protected BaseEntity(Guid id, DateTime dataCriacao, bool ativo, Guid? usuarioCriacaoId, Guid? usuarioModificacaoId)
        {
            Id = id;
            DataCriacao = dataCriacao;
            DataModificacao = DateTime.Now;
            Ativo = ativo;
            UsuarioCriacaoId = usuarioCriacaoId;
            UsuarioModificacaoId = usuarioModificacaoId;
        }

        public virtual void Desativar(Guid? usuarioModificacaoId)
        {
            SetAtivo(false);
            Atualizar(usuarioModificacaoId);
        }
        public virtual void Ativar(Guid? usuarioModificacaoId)
        {
            SetAtivo(true);
            Atualizar(usuarioModificacaoId);
        }

        public void Atualizar(Guid? usuarioModificacaoId)
        {
            DataModificacao = DateTime.Now;
            UsuarioModificacaoId = usuarioModificacaoId;
        }
        private void SetAtivo(bool ativo) => Ativo = ativo;
    }
}
