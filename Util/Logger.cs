using System;
using System.IO;

namespace Util
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            if (File.Exists(@"C:\Windows\Temp\logErroresAcademia.txt"))
            {
                StreamWriter archivo = File.AppendText(@"C:\Windows\Temp\logErroresAcademia.txt");
                archivo.WriteLine("---------------------------------------------------" +
                    "------------------------------------------------------------------");
                archivo.WriteLine($"{DateTime.Now} : {message}");
                archivo.Close();
            }

            else
            {
                StreamWriter escritor = new StreamWriter(@"C:\Windows\Temp\logErroresAcademia.txt");
                escritor.WriteLine($"{DateTime.Now} : {message}");
                escritor.Close();
            }
           
        }

    }

}
