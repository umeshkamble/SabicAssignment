using Microsoft.AspNetCore.SignalR;

namespace SignalRApplication
{
    public class ChatConnector:Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);
            await Clients.All.SendAsync("ChatReceived", message);
        }
    }
}
