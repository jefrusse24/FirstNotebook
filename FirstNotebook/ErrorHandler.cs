using System;
using System.Windows.Forms;

namespace FirstNotebook
{
    public static class ErrorHandler
    {
        public static void Error(Type className, string method, string message, Exception e)
        {
            if (className == null)
            {
                return;
            }

            MessageBox.Show($"Error in {className.ToString()}\nMethod: {method}\nMessage: {message}", "Error",   MessageBoxButtons.OK);
        }
    }
}
