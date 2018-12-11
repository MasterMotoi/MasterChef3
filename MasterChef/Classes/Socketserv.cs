using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Classes
{
    class SocketServ
    {
        public static void StartServer()
        {

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);


            try
            {
   
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
 
                listener.Bind(localEndPoint);

                listener.Listen(10);

                Socket handler = listener.Accept();

                string data = " ";
                byte[] bytes = null;

                while (data != null)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    handler.Send(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
