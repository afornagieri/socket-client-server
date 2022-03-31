using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333);
                socket.Connect(endPoint);

                Console.WriteLine("Connected !");
                Console.WriteLine("\n");

                string info = Console.ReadLine();

                byte[] infoSend = Encoding.Default.GetBytes(info);

                socket.Send(infoSend, 0, infoSend.Length, SocketFlags.None);

            }
            catch (Exception)
            {
                Console.WriteLine("Error, connection closed.");
            }

            socket.Close();
            Console.WriteLine("Press any key to exit...");
           
        }
    }
}
