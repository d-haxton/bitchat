using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Casascius.Bitcoin;

namespace Bitchat.Encryption
{
    class BitcoinAddress
    {
        private string privateKey;
        public string privateKeyHex { get; set; }
        public string publicKeyHex { get; set; }
        public string publicHash { get; set; }
        public string btcAddress { get; set; }
        public BitcoinAddress(string passedPrivateKey)
        {
            privateKey = passedPrivateKey;
        }

        public void mineFromPrivate()
        {
            // seriousl'

            try
            {
                object interpretation = StringInterpreter.Interpret(privateKey, compressed: false, addressType: 0);
                KeyPair kp = null;
                if (interpretation is PassphraseKeyPair)
                {
                    PassphraseKeyPair ppkp = (PassphraseKeyPair)interpretation;
                    kp = ppkp.GetUnencryptedPrivateKey();
                }
                else if (interpretation is KeyPair)
                {
                    kp = (KeyPair)interpretation;
                }

                if (kp == null)
                {
                    MessageBox.Show("Not a valid private key.");
                    return;
                }
                privateKeyHex = kp.PrivateKeyHex.Replace(" ", string.Empty);
                publicKeyHex = kp.PublicKeyHex.Replace(" ", string.Empty);
                publicHash = kp.Hash160Hex.Replace(" ", string.Empty);
                btcAddress = new AddressBase(kp, 0).AddressBase58.Replace("  ", string.Empty);
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message);
            }
        }
    }
}
