using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bitchat.Socket
{
    class Message
    {
        public string username { get;set; }
        public string encryptedMessage { get; set; }

        public Message()
        {

        }
    }
    class OpenChat
    {
        public string username { get; set; }
        public string personToChat { get; set; }
        public OpenChat() { }
    }
    class AddFriend
    {
        public string username { get; set; }
        public string friendId { get; set; }
        public AddFriend() { }
    }
    class LoginRequest
    {
        public string opcode = "0x0D";
        public string username { get; set; }
        public string publicKey { get; set; }
        public LoginRequest() { }
    }
    class MessageBit
    {
        //"publicKey":publicKey,"username":username,"encryptedText":encryptedText,"chatter":chatterID
        public string opcode = "0x16";
        public string messageType { get; set; }
        public string publicKey { get; set; }
        public string username { get; set; }
        public string encryptedText { get; set; }
        public string chatterID { get; set; }
        public MessageBit() { }
}
    class Client
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream;
        public Client()
        {
            clientSocket = new TcpClient();
            clientSocket.Connect("172.17.181.158", 9090);

            serverStream = clientSocket.GetStream();
            Thread t = new Thread(new ThreadStart(this.read));
            t.Start();
            t.IsBackground = true;
        }
        public void send(String data)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
        public void read()
        {
            while (true)
            {
                byte[] inStream = new byte[65525000];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                //Parse
                new Parser(Encoding.ASCII.GetString(inStream));
            }
        }
    }
}
