using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Plugin
{
    static class RuPhoneNumbers
    {
        static List<string> history = new List<string>();

        static public string GetPhoneNumber(string text, string prefix = "")
        {
            List<char> cha = text.Where(x => IsNum(x)).ToList();
            if (cha.Count < 10) return null;
            if (cha.Count > 11) return null;
            if (cha.Count == 11 && (!(cha[0] == '7' || cha[0] == '8'))) return null;
            if (cha.Count == 11) cha.RemoveAt(0);
            history.Add($"{text}\t{prefix}{string.Join("", cha)}");
            return $"{prefix}{string.Join("", cha)}";
        }

        static public bool IsPhoneNumber(string number)
        {
            number = Regex.Replace(number, @"[\(\)-]", "");
            return
                (
                Regex.IsMatch(number, @"^((\+7)|7|8)\d{10}$")
                ||
                Regex.IsMatch(number, @"^((\+7)|7|8)\(\d\d\d\)\d\d\d\d\d\d\d$")
                ||
                Regex.IsMatch(number, @"^((\+7)|7|8)\(\d\d\d\)\d\d\d-\d\d-\d\d$")
                );
        }

        static public string GetPhoneNumbersIgnoreOneSpace(string text, string prefix = "")
        {
            return GetPhoneNumbersIgnoreSpaces(text.Replace("  ", "\t"), prefix);
        }

        static public string GetPhoneNumbersIgnoreSpaces(string text, string prefix = "")
        {
            return GetPhoneNumbers(text.Replace(" ", ""), prefix);
        }

        static public string GetPhoneNumbers(string text, string prefix = "")
        {
            history.Clear();
            text = Regex.Replace(text, @"[\(\)-]", "");
            string[] texts = Regex.Split(text, @"[\W+]");
            texts = texts.Select(x => GetPhoneNumber(x, prefix)).Where(x => x != null).ToArray();
            return string.Join(Environment.NewLine, texts);
        }

        private static bool IsNum(char ch)
        {
            return ch >= '0' && ch <= '9';
        }
    }

}
