using System;
using System.Windows.Forms;

namespace Bitchat.Security
{
    class KeyGen
    {
        private String charMap;
        private bool didGenKeyStroke;
        private Random r;

        public KeyGen()
        {
            charMap = "abcdefghijklmnopqrstuvwxyz1234567890";
            didGenKeyStroke = false;
            r = new Random();
        }

        public void genKeyStroke()
        {
            didGenKeyStroke = true;
            SendKeys.Send("" + this.charMap[r.Next(this.charMap.Length - 1)]);
        }

        public bool getDidGenKeyStroke()
        {
            return didGenKeyStroke;
        }

        public void setDidGenKeyStroke(bool didGenKeyStroke)
        {
            this.didGenKeyStroke = didGenKeyStroke;
        }
    }
}
