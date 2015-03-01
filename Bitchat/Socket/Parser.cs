using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bitchat.Encryption;

namespace Bitchat.Socket
{
    class Parser
    {
        public static byte[] StringToByteArray(String hex)
        {
            return Convert.FromBase64String(hex);
        }
        public static String ByteArrayToString(byte[] ba)
        {
            return Convert.ToBase64String(ba);
        }
        public Parser(string json)
        {
            try
            {
                var o = JObject.Parse(json);
                string opcode = (string)o["opcode"];
                if (opcode.Equals("0x16"))
                {
                    ECDSAEncryption ecdsacrypto = new ECDSAEncryption(Global.publicKeyHex, Global.privateKeyHex);
                    MessageBit mb = JsonConvert.DeserializeObject<MessageBit>(json);
                    //Global.messageQueue.Push(json);
                    if (mb.messageType.Equals("handshake"))
                        new Handshake(mb, 2);
                    else if (mb.messageType.Equals("init"))
                        new Handshake(mb, 1);
                    else if (mb.messageType.Equals("finalize"))
                        new Handshake(mb, 3);
                    else if (mb.messageType.Equals("chat"))
                    {
                        try
                        {
                            ECDSAEncryption ECDSACrypto = Global.EncryptionDict[mb.username];
                            ECDSACrypto.decrypt(mb.encryptedText);
                            string decrypted = ECDSACrypto.decryptedMessage;
                            Global.messageQueue.Push("They said: " + decrypted);
                        }
                        catch(Exception ex)
                        {
                            //Global.messageQueue.Push(ex.Message);
                        }

                    }
                        

                    if (mb.messageType.Equals("DH"))
                    {
                        Global.bitDH.generateDerviedKey(StringToByteArray(mb.encryptedText));

                        MessageBit rmb = new MessageBit();
                        rmb.chatterID = mb.username;   

                        string bytesAsString = ByteArrayToString(Global.bitDH.publicKey);

                        //Global.messages.Push(ByteArrayToString(Global.bitDH.derivedKey));

                        rmb.opcode = "0x16";
                        rmb.encryptedText = bytesAsString;
                        rmb.publicKey = "043D4AF2F97878BEEF0220F6F17E2ABB694BAC3F74C1FFE8DEAFFE27D09DDE7629E8B601306BF59FE3C282E639066C510099F15BBCBFF3F28F70DCCBE02074AF3D";
                        rmb.username = "evan";
                        rmb.messageType = "DH";

                        string myjson = JsonConvert.SerializeObject(rmb);
                        Global.client.send(myjson);
                    }
                    
                }
            }
            catch (Exception)
            { }
        }
    }
}
