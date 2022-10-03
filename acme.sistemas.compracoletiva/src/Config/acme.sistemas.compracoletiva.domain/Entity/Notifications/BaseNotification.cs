using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace acme.sistemas.compracoletiva.domain.Entity.Notifications
{
    [NotMapped]
    public class BaseNotification 
    {
        private readonly List<Notification> _notifications;
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool PossuiNotificacoes => _notifications.Any();

        public BaseNotification()
        {
            _notifications = new List<Notification>();
        }

        public void Add(string key, string message) => Add(new Notification(key, message));
        public void Add(Notification notificacaos) => _notifications.Add(notificacaos);        
        public void Add(ICollection<Notification> notifications) => _notifications.AddRange(notifications);
        public void Add(IReadOnlyCollection<Notification> notifications) => _notifications.AddRange(notifications);       
        public void Add(IList<Notification> notifications) => _notifications.AddRange(notifications);
        public virtual bool IsValid() => !_notifications.Any();
    }
}
