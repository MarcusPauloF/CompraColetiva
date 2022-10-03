using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.core.Base
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
