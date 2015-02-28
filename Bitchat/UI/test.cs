using Bitchat.Encryption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitchat.UI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            ECDSAEncryption ECDSAencrypt = new ECDSAEncryption("043D4AF2F97878BEEF0220F6F17E2ABB694BAC3F74C1FFE8DEAFFE27D09DDE7629E8B601306BF59FE3C282E639066C510099F15BBCBFF3F28F70DCCBE02074AF3D", "7482D66852F9F1DA210037452692C0A4139FC871164CF55D7C20E25B90BC4700");
            ECDSAencrypt.encrypt("lolwtf");
            ECDSAencrypt.decrypt();
            textBox1.Text = ECDSAencrypt.decryptedMessage;

            /*
            BitDiffieHellmen bitDH1 = new BitDiffieHellmen();
            bitDH1.generatePublicKey();
            BitDiffieHellmen bitDH2 = new BitDiffieHellmen();
            bitDH2.generatePublicKey();

            bitDH1.generateDerviedKey(bitDH2.publicKey);
            bitDH2.generateDerviedKey(bitDH1.publicKey);

            //label1.Text = string.Join("", bitDH1.derivedKey);
            //label2.Text = string.Join("", bitDH2.derivedKey);

            byte[] testByte = new byte[32];
            testByte[1] = 0xFF;
            BitAES myAes = new BitAES(bitDH1.derivedKey);
            BitAES yourAes = new BitAES(bitDH2.derivedKey);
            label1.Text = "tits";
            byte[] encrypted = myAes.EncryptStringToBytes_Aes("okay", myAes.key, myAes.IV);
            string decrypted = myAes.DecryptStringFromBytes_Aes(encrypted, yourAes.key, yourAes.IV);
            label1.Text = decrypted;*/
        }
    }
}
