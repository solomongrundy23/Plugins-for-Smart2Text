using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugin
{
    public partial class DialogForm : Form
    {
        public DialogForm(string inText, string Title)
        {
            InitializeComponent();
            inner = inText;
            var splitters = new Dictionary<string, char>()
            {
                { "Tab", '\t'},
                { "Space", ' '},
                { "=", '='},
                { ";", ';'},
                { ",", ','},
                { ":", ':'},
                { "-", '-'},
                { ".", '.'},
                { "|", '|'},
                { "\\", '\\'},
                { "/", '/'}
            };
            comboBox1.DataSource = new BindingSource(splitters, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            var types = new Dictionary<string, byte>()
            {
                { "Только переменные", 0},
                { "Только значения", 1},
                { "Поменять переменные и значения местами", 2},
            };
            comboBox2.DataSource = new BindingSource(types, null);
            comboBox2.DisplayMember = "Key";
            comboBox2.ValueMember = "Value";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0;
        }

        public string inner;
        public string outer;
        public Thread BackgroundJob

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Work()
        { 

        }
    }
}
