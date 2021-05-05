using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Holen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your webiste:");
            string url = Console.ReadLine();
            if(!url.Contains("https:"))
            {
                url = $"https://{url}";
            }
            Holen(url);
        }
        static void Holen(string url)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var uri = new Uri(url);
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            var ping = new Ping();
            PingReply reply = ping.Send(uri.Host);

            Console.WriteLine($"\nUrl: {url}");
            Console.WriteLine($"Scheme: {uri.Scheme}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Host: {uri.Host}");

            Console.WriteLine("IP Addresses: ");
            foreach (IPAddress address in entry.AddressList)
            {
                Console.WriteLine(address);
            }   
            Console.WriteLine($"Ping: {reply.RoundtripTime}ms");
        }
    }
}
