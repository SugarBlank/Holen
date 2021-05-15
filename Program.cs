using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Holen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter your webiste:");
                string url = Console.ReadLine();
                if(!url.Contains("https:"))
                {
                    url = $"https://{url}";
                }
                Holen(url);
                Console.WriteLine($"Internet speed is: {GetInternetSpeed(url)} kb/sec");
            }
            else
            {
                string url = (args[0]);
                if(!url.Contains("https:"))
                {
                    url = $"https://{url}";
                }
                Holen(url);
                Console.WriteLine($"Internet speed is: {GetInternetSpeed(url)} kb/sec");
            }
        }
        static double GetInternetSpeed(string url)
        {
            WebClient client = new WebClient();
            DateTime time1 = DateTime.Now;
            byte[] data = client.DownloadData(url);
            DateTime time2 = DateTime.Now;
            return Math.Round((data.Length / 1024) / (time2 - time1).TotalSeconds, 2);
        }
        static void Holen(string url)
        {
            var speed = NetworkInterface.GetAllNetworkInterfaces();
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
