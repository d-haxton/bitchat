using Bitchat.Socket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Encryption
{
    class Handshake
    {
        string talkingToAddress;
        BitAES myAes;
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
        public Handshake(string btcTalker)
        {
            ECDSAEncryption ecdsacrypto = new ECDSAEncryption(null, Global.privateKeyHex);
            BitDiffieHellmen bitDH = new BitDiffieHellmen();

            bitDH.generatePublicKey();

            MessageBit replyBit = new MessageBit();
            replyBit.chatterID = btcTalker;
            replyBit.username = Global.btcAddress;
            replyBit.messageType = "init";
            ecdsacrypto.encrypt(ByteArrayToString(bitDH.publicKey));
            replyBit.encryptedText = ecdsacrypto.encryptedMessage;
            replyBit.publicKey = Global.publicKeyHex;

            string json = JsonConvert.SerializeObject(replyBit);
            Global.client.send(json);
        }
        public Handshake(MessageBit mb, int init)
        {
            mb.username = talkingToAddress;
            if (init == 1) {
                BitDiffieHellmen bitDH = new BitDiffieHellmen();

                bitDH.generatePublicKey();

                MessageBit replyBit = new MessageBit();
                replyBit.chatterID = mb.username;
                replyBit.username = Global.btcAddress;
                replyBit.messageType = "handshake";
                replyBit.encryptedText = "";
                replyBit.publicKey = Global.publicKeyHex;

                string json = JsonConvert.SerializeObject(replyBit);
                Global.client.send(json);
            }
            else if(init == 2)
            {
                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, Global.privateKeyHex);
                ecdsacrypto.encryptedMessage = mb.encryptedText;
                ecdsacrypto.decrypt();

                BitDiffieHellmen bitDH = new BitDiffieHellmen();
                bitDH.generateDerviedKey(StringToByteArray(ecdsacrypto.decryptedMessage));

                myAes = new BitAES(bitDH.derivedKey);
                Global.AESKeyChain.Add(mb.username, myAes);

                MessageBit replyBit = new MessageBit();
                replyBit.chatterID = mb.username;
                replyBit.username = Global.btcAddress;
                replyBit.messageType = "finalize";
                ecdsacrypto.encrypt(ByteArrayToString(bitDH.publicKey));
                replyBit.encryptedText = ecdsacrypto.encryptedMessage;
                replyBit.publicKey = Global.publicKeyHex;

                string json = JsonConvert.SerializeObject(replyBit);
                Global.client.send(json);
            }
            else if(init == 3)
            {
                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, Global.privateKeyHex);
                ecdsacrypto.encryptedMessage = mb.encryptedText;
                ecdsacrypto.decrypt();

                BitDiffieHellmen bitDH = new BitDiffieHellmen();
                bitDH.generateDerviedKey(StringToByteArray(ecdsacrypto.decryptedMessage));

                myAes = new BitAES(bitDH.derivedKey);
                Global.AESKeyChain.Add(mb.username, myAes);
            }
        }
    }
}
