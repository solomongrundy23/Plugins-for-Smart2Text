using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Plugin
{
    public class PluginClass
    {
        public string DoWork(string Input)
        {
            try
            {
                DialogForm form = new DialogForm(Input, About());
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return form.outter;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public string About(string Param = "")
        {
            return "Вытащить список телефонных номеров(РФ)";
        }
    }
}
