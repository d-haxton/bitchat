using Bitchat.Encryption;
using Bitchat.Socket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat
{
    class Global
    {
        public static Client client;
        public static Stack<string> messages = new Stack<string>();
        public static String username = "";
        public static String btcAddress = "";
        public static String privateKey = "";
        public static String publicKeyHex = "";
        public static String privateKeyHex = "";

        public static BitDiffieHellmen bitDH = new BitDiffieHellmen();
        public static Dictionary<string, ECDSAEncryption> EncryptionDict = new Dictionary<string, ECDSAEncryption>();

        public static Stack<string> messageQueue = new Stack<string>();

        public static bool openChat = false;
        public static string openChatString = "";

        public static byte[] bitDHKey;
    }
}
