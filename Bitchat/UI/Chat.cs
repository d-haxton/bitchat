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
    public partial class Chat : Form
    {
        private string chatUser;
        public Chat(string chatUserInput)
        {
            this.chatUser = chatUserInput;
            InitializeComponent();
            this.Text = "Chatting with - " + chatUser;
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
    }
}
