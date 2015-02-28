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
            label1.Text = decrypted;
        }
    }
}
