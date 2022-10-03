using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.core.Dtos.Product;

namespace acme.sistemas.compracoletiva.domain.Entity.Product
{
    public class Oferta : BaseEntity, IAggregateRoot
    {
        public Oferta()
        {

        }

        public string Titulo { get; private set; }   
        public string Descricao { get; private set; }
        public string Condicao { get; private set; }
        public string PalavraChavePesquisa { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataTermino { get; private set; }
        public decimal ValorProduto { get; private set; }
        public decimal ValorComDesconto { get; private set; }
        public int QuantidadeOfertaDisponivel { get; private set; }
        public bool Fornecedor { get; private set; }
        public bool Comprador { get; private set; }
        public Guid UsuarioId { get; private set; }

        public Usuario Usuario { get; private set; }


        public void Atualizar(Oferta oferta)
        {
            if (this.Titulo != oferta.Titulo)
                Titulo = oferta.Titulo;

            if (this.Descricao != oferta.Descricao)
                Descricao = oferta.Descricao;

            if (this.Condicao != oferta.Condicao)
                Condicao = oferta.Condicao;

            if (this.PalavraChavePesquisa != oferta.PalavraChavePesquisa)
                PalavraChavePesquisa = oferta.PalavraChavePesquisa;

            if (this.DataInicio != oferta.DataInicio)
                DataInicio = oferta.DataInicio;

            if (this.DataTermino != oferta.DataTermino)
                DataTermino = oferta.DataTermino;

            if (this.ValorProduto != oferta.ValorProduto)
                ValorProduto = oferta.ValorProduto;

            if (this.ValorComDesconto != oferta.ValorComDesconto)
                ValorComDesconto = oferta.ValorComDesconto;

            if (this.QuantidadeOfertaDisponivel != oferta.QuantidadeOfertaDisponivel)
                QuantidadeOfertaDisponivel = oferta.QuantidadeOfertaDisponivel;

            if (this.Fornecedor != oferta.Fornecedor)
                Fornecedor = oferta.Fornecedor;

            if (this.Comprador != oferta.Comprador)
                Comprador = oferta.Comprador;

            if (this.UsuarioId != oferta.UsuarioId)
                UsuarioId = oferta.UsuarioId;

            base.Atualizar(oferta.UsuarioModificacaoId);
        }


        public void Ofertar(OfertaDto ofertaDto)
        {
          Titulo = ofertaDto.Titulo;
            Descricao = ofertaDto.Descricao;
            Condicao = ofertaDto.Condicao;
            DataInicio = ofertaDto.DataInicio;
            DataTermino = ofertaDto.DataTermino;
            ValorProduto = ofertaDto.ValorProduto;
            ValorComDesconto = ofertaDto.ValorComDesconto;
            QuantidadeOfertaDisponivel = ofertaDto.QuantidadeOfertaDisponivel;
        }
    }
}
