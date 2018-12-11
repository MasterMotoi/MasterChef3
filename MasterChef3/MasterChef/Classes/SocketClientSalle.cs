using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Classes
{
    class SocketClientSalle
    {
        public static void Salle()
        {
            byte[] bytes = new byte[1024];

            try
            {

                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
   
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    string msg = " ";
                    sender.Connect(remoteEP);

                    while (msg != null) {
                    byte[] bmsg = Encoding.ASCII.GetBytes(msg);
                    int bytesSent = sender.Send(bmsg);
                    int bytesRec = sender.Receive(bytes);
                    msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    }


                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Message(string msg)
        {
            byte[] bytes = new byte[1024];

            try
            {

                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                        byte[] bmsg = Encoding.ASCII.GetBytes(msg);
                        int bytesSent = sender.Send(bmsg);
                        int bytesRec = sender.Receive(bytes);
                        msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
