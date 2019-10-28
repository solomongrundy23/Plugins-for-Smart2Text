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
                string[] texts = Regex.Split(Input, @"[\W+]");
                Int64 result = 0;
                Int64 count = 0;
                foreach (string s in texts)
                {
                    int Element;
                    if (int.TryParse(s, out Element))
                    {
                        result += Element;
                        count++;
                    }
                }
                if (count == 0) return null;
                if (!Input.EndsWith(Environment.NewLine)) Input += Environment.NewLine;
                return $"{Input}Сумма: {result}" +
                    $"{Environment.NewLine}Среднее значение: {result/count}";
            }
            catch
            {
                throw new Exception("Не удалось");
            }
        }

        public string About(string Param = "")
        {
            return "Сумма и среднее всех чисел";
        }
    }
}
