using System.ComponentModel.DataAnnotations.Schema;

namespace acme.sistemas.compracoletiva.domain.Entity.Notifications
{
    [NotMapped]
    public class Notification
    {
        public Notification()
        {

        }
        public Notification(string key, string message)
        {
            Message = message;
            Key = key;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }
    }
}
