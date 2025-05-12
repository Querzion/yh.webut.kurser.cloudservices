// using System.Web.Services.Description;
// using System;
// using System.ServiceModel;
// using System.ServiceModel.Channels;
// using Contracts;
//
// namespace Client;
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.Write("Enter name: ");
//         var name = Console.ReadLine();
//         CallService("http://localhost:80/NameService", new BasicHttpBinding(), name!);
//         
//         Console.Write("Enter name: ");
//         name = Console.ReadLine();
//         CallService("net.tcp://localhost:8090/NameService", new NetTcpBinding(), name!);
//         
//         // Console.Write("Enter name: ");
//         // name = Console.ReadLine();
//         // CallService("net.pipe://localhost/NameService", new NetNamedPipeBinding(), name!);
//
//         Console.ReadKey();
//     }
//
//     static void CallService(string address, BasicHttpBinding binding, string name)
//     {
//         var endpoint = new EndPointAddress(address);
//         var factory = new ChannelFactory<INameService>(binding, endpoint);
//         var proxy = factory.CreateChannel();
//
//         proxy.AddName(name);
//         var result = proxy.GetNames();
//         
//         Console.WriteLine("Current Names:");
//         foreach (var current in result)
//             Console.WriteLine(current);
//
//         ((IClientChannel)proxy).Close();
//         factory.Close();
//     }
// }