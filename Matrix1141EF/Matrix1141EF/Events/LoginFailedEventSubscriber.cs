using System;
using System.Threading.Tasks;

namespace Matrix1141EF.Events
{
    public  class LoginFailedEventSubscriber
    {
        internal static EventHandler<LoginFailedEvent> handleLoginFailed()
        {
            throw new NotImplementedException();
        }

        public  async Task HandleLoginFailed(object sender, LoginFailedEvent e)
        {
            Console.WriteLine($"Login failed for {e.Username} at {e.Timestamp}");

            await Task.CompletedTask; 
        }
    }
}
