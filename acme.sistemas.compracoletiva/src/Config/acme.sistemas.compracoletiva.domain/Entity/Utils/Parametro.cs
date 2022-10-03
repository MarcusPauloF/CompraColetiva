

using acme.sistemas.compracoletiva.core.Base;

namespace acme.sistemas.compracoletiva.domain.Entity.Utils
{
    public class Parametro : BaseEntity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Valor { get; private set; }
        public string Descricao { get; private set; }

        protected Parametro() { }

        public Parametro(string nome, string valor, string descricao) : base()
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
        }

        public void Atualizar(Parametro parametro)
        {
            if (this.Nome != parametro.Nome)
                Nome = parametro.Nome;

            if(this.Valor != parametro.Valor)
                Valor = parametro.Valor;

            if (this.Descricao != parametro.Descricao)
                Descricao = parametro.Descricao;

            base.Atualizar(parametro.UsuarioModificacaoId);
        }
    }
}
