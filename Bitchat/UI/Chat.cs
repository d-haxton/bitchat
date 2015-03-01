using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bitchat.Security;

namespace Bitchat.UI
{
    public partial class Chat : Form
    {
        private KeyGen kg;
        private KeysConverter kc;
        private RegisterHotKeyClass _RegisKey;
        private int currPos;

        private string chatUser;
        public Chat(string chatUserInput)
        {
            kg = new KeyGen();
            kc = new KeysConverter();
            _RegisKey = new RegisterHotKeyClass();
            currPos = 0;

            this.chatUser = chatUserInput;
            InitializeComponent();
            this.Text = "Chatting with - " + chatUser;
        }

        void _Regis_HotKey()
        {
            MessageBox.Show("i catch u");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("You said: " + textBox1.Text);
            listBox1.TopIndex = listBox1.Items.Count - 1;
            textBox1.Text = "";
            textBox1.Select();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Chat_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Text = "" + (char)e.KeyCode;
            if (kg.getDidGenKeyStroke())
            {
                kg.setDidGenKeyStroke(false);
            }
            else if (!kg.getDidGenKeyStroke())
            {
                if (e.KeyCode == Keys.Back && textBox1.TextLength > 0)
                {
                    this.textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
                    currPos--;
                }
                else if (e.KeyCode == Keys.Space)
                {
                    this.textBox1.Text += ' ';
                    currPos++;
                }
                
                else if ((char)e.KeyCode == '½')
                {
                    this.textBox1.Text += "-";

                    textBox1.SelectionStart++;
                }
                else if ((char)e.KeyCode == '¼')
                {
                    this.textBox1.Text += ",";

                    currPos++;
                }
                else if ((char)e.KeyCode == '¾')
                {
                    this.textBox1.Text += ".";

                    currPos++;
                }
                else if ((char)e.KeyCode == '¿')
                {
                    this.textBox1.Text += '?';

                    currPos++;
                }
                else if ((char)e.KeyCode == 'º')
                {
                    this.textBox1.Text += ";";

                    currPos++;
                }
                else if ((char)e.KeyCode == 'À')
                {
                    this.textBox1.Text += "'";

                    currPos++;
                }
                else if (Char.IsLetter(kc.ConvertToString(e.KeyCode)[0]))
                {
                    if (kc.ConvertToString(e.KeyCode).Length == 1)
                    {
                        this.textBox1.Text += kc.ConvertToString(e.KeyCode).ToLower();

                        currPos++;
                    }
                }
                else if (Char.IsNumber((char)e.KeyCode))
                {
                    this.textBox1.Text += (char)e.KeyCode;

                    currPos++;
                }

                textBox1.SelectionStart = currPos;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kg.setDidGenKeyStroke(true);
            kg.genKeyStroke();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            _RegisKey.Keys = Keys.PrintScreen;
            _RegisKey.ModKey = 0;
            _RegisKey.WindowHandle = this.Handle;
            _RegisKey.HotKey += new RegisterHotKeyClass.HotKeyPass(_Regis_HotKey);
            _RegisKey.StarHotKey();
        }

        private void Chat_Activated(object sender, EventArgs e)
        {
            listBox1.BackColor = SystemColors.Window;
            textBox1.BackColor = SystemColors.Window;
        }

        private void Chat_Deactivate(object sender, EventArgs e)
        {
            listBox1.BackColor = SystemColors.WindowText;
            textBox1.BackColor = SystemColors.WindowText;
        }



    }
}
