using System;
using System.Windows.Forms;

namespace FirstNotebook
{
    public static class ErrorHandler
    {
        public static void Error(Type className, string method, string message, Exception exception)
        {
            if (className == null)
            {
                return;
            }

            MessageBox.Show($"Error in {className.ToString()}\nMethod: {method}\nMessage: {message}", "Error",   MessageBoxButtons.OK);
            Console.WriteLine(exception.ToString());
        }
    }
}
