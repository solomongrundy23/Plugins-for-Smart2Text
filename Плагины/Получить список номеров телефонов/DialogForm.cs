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
            Text = Title;
            inner = inText;
            DialogResult = DialogResult.Cancel;
            Dictionary<string, string> slovar = new Dictionary<string, string>();
            slovar.Add("", "Без префикса");
            slovar.Add("8", "Национальный (8)");
            slovar.Add("7", "Международный (7)");
            slovar.Add("+7", "Мобильный (+7)");
            comboBox1.DataSource = new BindingSource(slovar, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
        }

        public delegate string GetPhoneDelegate(string text, string prefix = "");
        public GetPhoneDelegate GetPhones = RuPhoneNumbers.GetPhoneNumbers;
        string inner
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value ?? ""; }
        }
        private string prefix
        {
            get { return ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key; }
        }
        public string outter
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value ?? ""; }
        }
        Thread BackWorking;

        private void BackWorkingStart()
        {
            try
            {
                if (BackWorking != null)
                    if (BackWorking.IsAlive) BackWorking.Abort();
                BackWorking = new Thread(delegate () { BackWorkingThread(inner, prefix); });
                BackWorking.IsBackground = true;
                progressBar1.Visible = true;
                BackWorking.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackWorkingThread(string text, string prefix = "")
        {
            try
            {
                string x = GetPhones(text, prefix);
                Invoke(new Action(() => { outter = x; progressBar1.Visible = false; }));
            }
            catch
            {

            }
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GetPhones = RuPhoneNumbers.GetPhoneNumbers;
            BackWorkingStart();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GetPhones = RuPhoneNumbers.GetPhoneNumbersIgnoreOneSpace;
            BackWorkingStart();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GetPhones = RuPhoneNumbers.GetPhoneNumbersIgnoreSpaces;
            BackWorkingStart();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BackWorkingStart();
        }
    }
}
