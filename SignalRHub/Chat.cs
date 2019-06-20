using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub
{
    public class Chat : Hub
    {
        public Task Send(string message) {
            System.Console.WriteLine(message);
            return Clients.Others.SendCoreAsync("Send", new [] { message});
        }
    }
}