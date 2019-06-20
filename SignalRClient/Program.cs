using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/ChatHub")
                .Build();

            connection.On<string>("Send", (message)=>{
                System.Console.WriteLine("Recibido:");
                System.Console.WriteLine(message);
            });

            connection.StartAsync().Wait();

            while (true) {
                System.Console.WriteLine("Escriba un mensaje:");
                var message = Console.ReadLine();
                connection.SendAsync("Send", message);
            }
        }
    }
}
