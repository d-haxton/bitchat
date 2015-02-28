using Bitchat.Encryption;
using Bitchat.Socket;
using Bitchat.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bitchat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // btcAddress = new BitcoinAddress("5Jhbhbft58D7dsGATiKCF5nQu8RxTLkdqJV9iX2LC9vP7868kKG");
            //btcAddress.mineFromPrivate();

            //textBox1.Text = btcAddress.privateKeyHex + "\n" + btcAddress.publicKeyHex + "\n" + btcAddress.publicHash + "\n" + btcAddress.btcAddress;
            /*
            ECDSAEncryption ECDSAencrypt = new ECDSAEncryption("043D4AF2F97878BEEF0220F6F17E2ABB694BAC3F74C1FFE8DEAFFE27D09DDE7629E8B601306BF59FE3C282E639066C510099F15BBCBFF3F28F70DCCBE02074AF3D", "7482D66852F9F1DA210037452692C0A4139FC871164CF55D7C20E25B90BC4700");
            ECDSAencrypt.encrypt("lolwtf");
            ECDSAencrypt.decrypt();
            textBox1.Text = ECDSAencrypt.decryptedMessage;*/

            //Client c = new Client();
            //MessageBox.Show(c.returnData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*BitcoinAddress btcAddress = new BitcoinAddress(textBox1.Text);
            btcAddress.mineFromPrivate();

            textBox4.Text = btcAddress.privateKeyHex;
            textBox5.Text = btcAddress.publicKeyHex;
            textBox2.Text = btcAddress.btcAddress;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* ECDSAEncryption ECDSAencrypt = new ECDSAEncryption(textBox5.Text, textBox4.Text);
            ECDSAencrypt.encrypt(textBox3.Text);
            ECDSAencrypt.decrypt();
            textBox6.Text = ECDSAencrypt.encryptedMessage;
            textBox7.Text = ECDSAencrypt.decryptedMessage;*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Friends f = new Friends();
            f.Show();
            // Send Login request to server
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }
    }
}
