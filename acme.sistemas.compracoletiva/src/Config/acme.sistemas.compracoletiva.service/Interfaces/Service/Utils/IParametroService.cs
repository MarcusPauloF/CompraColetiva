﻿using acme.sistemas.compracoletiva.domain.Entity.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.service.Interfaces.Service.Utils
{
    public interface IParametroService : IBaseService<Parametro>
    {
        Task<IEnumerable<Parametro>> GetAllParametro();
    }
}
