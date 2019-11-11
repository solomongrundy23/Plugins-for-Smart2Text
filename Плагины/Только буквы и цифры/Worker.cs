using System;
using System.Collections.Generic;
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
            return null;
        }

        internal static string GetString(string input)
        {
            return Converter.GetResult(input);
        }

        internal static class Converter
        {
            private static string alf = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnmёйцукенгшщзхъфывапролджэячсмитьбюЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";

            internal static string GetResult(string source)
            {
                var result = new StringBuilder();
                foreach (var letter in source)
                {
                    if (alf.Contains(letter)) result.Append(letter);
                }
                return result.ToString();
            }
        }
    }
}
