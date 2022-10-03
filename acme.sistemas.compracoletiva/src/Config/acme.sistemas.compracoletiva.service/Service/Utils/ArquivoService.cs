using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using AutoMapper;

namespace acme.sistemas.compracoletiva.service.Service.Utils
{
    public class ArquivoService : BaseService<Arquivo>, IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IMapper _mapper;

        public ArquivoService(IArquivoRepository arquivoRepository,
            IMapper mapper) : base(arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
            _mapper = mapper;
        }
    }
}
