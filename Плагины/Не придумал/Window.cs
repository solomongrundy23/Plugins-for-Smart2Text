using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugin
{
    internal partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            listBox1.DataSource = Buffer;
        }

        private void AddBuf(string buf)
        {
            Buffer.Add(buf);
            listBox1.DataSource = null;
            listBox1.DataSource = Buffer;
            if (listBox1.Items.Count > 0) listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        internal List<string> Buffer = new List<string>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            string temp = Clipboard.GetText();
            if (temp != "")
            {
                if (Buffer.Count > 0)
                {
                    if (temp != Buffer.Last())
                    {
                        AddBuf(temp);
                    }
                }
                else
                {
                    AddBuf(temp);
                }
            }
        }
    }
}
