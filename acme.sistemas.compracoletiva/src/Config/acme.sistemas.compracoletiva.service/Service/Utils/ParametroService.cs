using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Utils
{
    public class ParametroService : BaseService<Parametro>, IParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IMapper _mapper;

        public ParametroService(IParametroRepository parametroRepository,
            IMapper mapper) : base(parametroRepository)
        {
            _parametroRepository = parametroRepository;
        }

        public async Task<IEnumerable<Parametro>> GetAllParametro()
        {
            return await _parametroRepository.GetAllParametro();
        }
    }
}
