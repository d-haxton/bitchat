using Bitchat.Socket;
using Bitchat.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bitchat.Encryption
{
    class Handshake
    {        
        public static byte[] StringToByteArray(String hex)
        {
            return Convert.FromBase64String(hex);
        }
        public static String ByteArrayToString(byte[] ba)
        {
            return Convert.ToBase64String(ba);
        }
        public Handshake(string btcTalker)
        {
            MessageBit replyBit = new MessageBit();
            replyBit.chatterID = btcTalker;
            replyBit.username = Global.btcAddress;
            replyBit.messageType = "init";
            replyBit.encryptedText = "";
            replyBit.publicKey = Global.publicKeyHex;

            string json = JsonConvert.SerializeObject(replyBit);
            Global.client.send(json);
        }
        public Handshake(MessageBit mb, int init)
        {
            if (init == 1)
            {
                Global.openChatString = mb.username;
                Global.openChat = true;

                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, Global.privateKeyHex);

                Global.EncryptionDict.Add(mb.username, ecdsacrypto);

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

                Global.EncryptionDict.Add(mb.username, ecdsacrypto);
            }

            // receive init
            /*if (init == 1) {
                Global.openChatString = mb.username;
                Global.openChat = true;
               
                BitDiffieHellmen bitDH = new BitDiffieHellmen();

                AesManaged aes = new AesManaged();

                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, null);

                ecdsacrypto.encrypt(ByteArrayToString(bitDH.publicKey));

                MessageBit replyBit = new MessageBit();
                replyBit.chatterID = mb.username;
                replyBit.username = Global.btcAddress;
                replyBit.messageType = "handshake";
                replyBit.encryptedText = ecdsacrypto.encryptedMessage;
                replyBit.publicKey = Global.publicKeyHex;

                string json = JsonConvert.SerializeObject(replyBit);
                Global.client.send(json);
            }
            //receive handshake
            else if(init == 2)
            {
                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, Global.privateKeyHex);
                ecdsacrypto.decrypt(mb.encryptedText);

                BitDiffieHellmen bitDH = new BitDiffieHellmen();
                //Global.messageQueue.Push("Public key: " + ByteArrayToString(bitDH.publicKey));

                bitDH.generateDerviedKey(StringToByteArray(ecdsacrypto.decryptedMessage));

                Global.AESKeyChain.Add(mb.username, StringToByteArray("JGT5bVFbN876nGQd2pE5rcqyWzcnPc5igUZJQ8VQFrU="));
                //Global.messageQueue.Push("Derived Key: " + ByteArrayToString(bitDH.derivedKey));

                MessageBit replyBit = new MessageBit();
                replyBit.chatterID = mb.username;
                replyBit.username = Global.btcAddress;
                replyBit.messageType = "finalize";
                ecdsacrypto.encrypt(ByteArrayToString(bitDH.publicKey));
                replyBit.encryptedText = ecdsacrypto.encryptedMessage;
                replyBit.publicKey = ecdsacrypto.decryptedMessage;

                string json = JsonConvert.SerializeObject(replyBit);
                Global.client.send(json);
            }
            //receive finalize
            else if(init == 3)
            {
                ECDSAEncryption ecdsacrypto = new ECDSAEncryption(null, Global.privateKeyHex);
                ecdsacrypto.decrypt(mb.encryptedText);

                BitDiffieHellmen bitDH = new BitDiffieHellmen();
                bitDH.publicKey = StringToByteArray(mb.publicKey);
                bitDH.generateDerviedKey(StringToByteArray(ecdsacrypto.decryptedMessage));
                //Global.messageQueue.Push("Public key: " + ByteArrayToString(bitDH.publicKey));

               // Global.messageQueue.Push("Derived Key: " + ByteArrayToString(bitDH.derivedKey));
                Global.AESKeyChain.Add(mb.username, StringToByteArray("JGT5bVFbN876nGQd2pE5rcqyWzcnPc5igUZJQ8VQFrU="));
            }*/
        }
    }
}
