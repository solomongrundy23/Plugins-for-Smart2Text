using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plugin
{
    internal static class Worker
    {
        internal static string GetString()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }

        internal static string GetString(string input)
        {
            StringBuilder result = new StringBuilder();
            char[] alf_left = "{[(".ToArray();
            char[] alf_right = "}])".ToArray();
            char[] alf_center = "`'\"".ToArray();
            for (byte i = 0; i < alf_left.Length; i++)
            {
                long a = input.Where(x => x == alf_left[i]).Count();
                long b = input.Where(x => x == alf_right[i]).Count();
                if (a > b) result.AppendLine($"{alf_left[i]} не хватает - {a - b}");
                if (a < b) result.AppendLine($"{alf_right[i]} не хватает - {b - a}");
            }
            foreach (char ch in alf_center)
                if (input.Where(x => x == ch).Count() % 2 > 0)
                    result.AppendLine($"{ch} не четное количество");
            if (result.Length > 0) 
                MessageBox.Show(result.ToString());
            else 
                MessageBox.Show("Проблем нет");
            return null;
        }
    }
}
