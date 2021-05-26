using Grpc.Net.Client;
using NodeF.Fragments.Authentcation;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("http://192.168.1.7:5000");
            var client = new AuthenticationProvider.AuthenticationProviderClient(channel);
            var reply = await client.ServiceStatusAsync(
                              new ServiceStatusRequest {  });
            Console.WriteLine("Status: " + reply.Status.ToString());
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
