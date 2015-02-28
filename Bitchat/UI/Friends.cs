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
    public partial class Friends : Form
    {
        public Friends()
        {
            InitializeComponent();
        }

        private void Friends_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Chat c = new Chat(listBox1.SelectedItem.ToString());
            c.Show();
        }

        private void redbullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wheres the redbull?!");
        }
    }
}
