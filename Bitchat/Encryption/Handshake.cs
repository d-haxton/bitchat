using Bitchat.Socket;
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
        public Handshake(string btcTalker)
        {
            talkingToAddress = btcTalker;
            // decrypt with ECDSA
           //ECDSAEncryption ecdsaecrypto = new ECDSAEncryption()
        }
        public Handshake(MessageBit mb)
        {
            mb.username = talkingToAddress;
            ECDSAEncryption ecdsacrypto = new ECDSAEncryption(mb.publicKey, Global.privateKeyHex);
            ecdsacrypto.encryptedMessage = mb.encryptedText;
            ecdsacrypto.decrypt();

            BitDiffieHellmen bitDH = new BitDiffieHellmen();
            bitDH.generateDerviedKey(StringToByteArray(ecdsacrypto.decryptedMessage));

            myAes = new BitAES(bitDH.derivedKey);

        }

        public void DHHandshake()
        {

        }
    }
}
