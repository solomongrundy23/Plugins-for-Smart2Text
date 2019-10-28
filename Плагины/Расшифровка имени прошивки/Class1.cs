using System;

namespace Plugin
{
    public class PluginClass
    {
        public string DoWork(string Input)
        {
            try
            {
                if (Input == string.Empty) return Input;
                string[] result = Worker.GetStrings(Input);
                return string.Join(Environment.NewLine, result);
            }
            catch
            {
                throw new Exception("Не удалось");
            }
        }

        public string About(string Param = "")
        {
            return "Расшифровка прошивки CAN";
        }
    }
}
