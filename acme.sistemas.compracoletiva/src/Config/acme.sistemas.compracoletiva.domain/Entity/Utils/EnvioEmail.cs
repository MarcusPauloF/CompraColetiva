using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Entity.Utils
{
    public class EnvioEmail : BaseEntity , IAggregateRoot
    {
        protected EnvioEmail()
        {

        }

        public string Titulo { get; private set; }
        public string Corpo { get; private set; }
        public Guid DestinatarioId { get; private set; }
        public Email Destinatario { get; private set; }

        public virtual ICollection<Email> EmailsCopias { get; private set; } = new HashSet<Email>();
    }
}
