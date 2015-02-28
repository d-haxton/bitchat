using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Socket
{
    class Client
    {
        TcpClient clientSocket = new TcpClient();
        public string returnData { get; set; }
        public Client()
        {
            clientSocket.Connect("172.17.181.158", 9090);

            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = { 0x0A, 0xFF, 0xFF, 0xFF };// System.Text.Encoding.ASCII.GetBytes("bigmoney");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            returnData = System.Text.Encoding.ASCII.GetString(inStream);
        }
    }
}
