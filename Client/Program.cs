using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static HubConnection HubConnection;
        static async Task Main(string[] args)
        {
            HubConnection = new HubConnectionBuilder().WithUrl("http://localhost:19929/notification").Build();
            HubConnection.On<String>("Send", message => Console.WriteLine($"Message from server: { message}"));

            await HubConnection.StartAsync();

            bool isExit = false;

            while (!isExit)
            {
                var message = Console.ReadLine();

                if (message != "Exit")
                {
                    await HubConnection.SendAsync("SendMessage", message);
                }
                else
                {
                    isExit = true;
                }
            }
            Console.ReadLine();
        }
    }
}
