using System;

namespace Plugin
{
    internal static class Worker
    {
        internal static string GetString()
        {
            Window window = new Window();
            try
            {
                if (window.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    return String.Join(Environment.NewLine, window.Buffer);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                window.Dispose();
            }
        }

        internal static string GetString(string input)
        {
            return null;
        }
    }
}
