using acme.sistemas.compracoletiva.core.Dtos.Product;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Interfaces.Service.Product
{
    public interface IOfertaService : IBaseService<Oferta>
    {
        void Ofertar(OfertaDto ofertaDto);
    }
}
