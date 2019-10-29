using System;

namespace Plugin
{
    public class PluginClass
    {
        public string DoWork(string Input)
        {
            try
            {
                return Worker.GetString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string About(string Param = "")
        {
            return "Запись буфера обмена";
        }
    }
}
