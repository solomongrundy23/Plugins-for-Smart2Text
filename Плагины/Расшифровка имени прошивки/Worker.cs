using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin
{
    static class Worker
    {
        static private string[] declist = new string[]
        {
                "встроенный автозапуск",
                "управление блоком автозапуска с подтверждением по + ",
                "управление блоком автозапуска с подтверждением по -",
                "встроенная блокировка запуска по CAN",
                "управление внешней блокировкой глушения по CAN (МКБ)",
                "управление отопителем с подтверждением по  -",
                "управление со штатных кнопок автомобиля",
                "чтение кодов неисправностей автомобиля"
        };

        static public string[] GetStrings(string s)
        {
            string[] string_list = s.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return string_list.Select(x => x.Trim()).Select(x => $"{x}{Environment.NewLine}{GetString(x)}").ToArray();
        }

        static private string GetString(string s)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                if (s.Length >= 4)
                {
                    string temp = s.Substring(s.Length - 4, 2);
                    temp = HexStringToBinary(temp);
                    for (int i = 7; i >= 0; i--)
                    {
                        if (temp[i] == '1') builder.AppendLine($"● " + declist[7 - i]);
                    }
                    return builder.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        static private string HexStringToBinary(string hexString)
        {
            var lup = new Dictionary<char, string>{
            { '0', "0000"},
            { '1', "0001"},
            { '2', "0010"},
            { '3', "0011"},

            { '4', "0100"},
            { '5', "0101"},
            { '6', "0110"},
            { '7', "0111"},

            { '8', "1000"},
            { '9', "1001"},
            { 'A', "1010"},
            { 'B', "1011"},

            { 'C', "1100"},
            { 'D', "1101"},
            { 'E', "1110"},
            { 'F', "1111"}};

            var ret = string.Join("", from character in hexString
                                      select lup[character]);
            return ret;
        }
    }
}
