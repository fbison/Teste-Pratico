using Flunt.Notifications;
using System;

namespace TestePratico.Domain.Models
{
    public class Notificacao : Notification
    {
        public Notificacao(string key, string message) : base(key, message)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Notificacao notificacao &&
                   Key == notificacao.Key &&
                   Message == notificacao.Message;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Message);
        }
    }
}
