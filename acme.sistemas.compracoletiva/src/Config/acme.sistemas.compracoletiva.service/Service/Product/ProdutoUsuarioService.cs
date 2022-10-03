using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Product;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Service.Product
{
    public class ProdutoUsuarioService : BaseService<ProdutoUsuario> , IProdutoUsuarioService
    {
        private readonly IProdutoUsuarioRepository _produtoUsuarioRepository;
        private readonly IMapper _mapper;

        public ProdutoUsuarioService(IProdutoUsuarioRepository produtoUsuarioRepository, IMapper mapper) : base(produtoUsuarioRepository)
        {
            _produtoUsuarioRepository = produtoUsuarioRepository;
            _mapper = mapper;
        }
    }
}
