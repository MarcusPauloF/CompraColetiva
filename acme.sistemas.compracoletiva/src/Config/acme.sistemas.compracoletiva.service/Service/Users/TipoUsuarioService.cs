using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Users
{
    public class TipoUsuarioService : BaseService<TipoUsuario>, ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository,
            IMapper mapper) : base(tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
            _mapper = mapper;
        }
    }


}
