using MasyvaiPrasidedaVienetu.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
namespace MasyvaiPrasidedaVienetu.Logging
{
    public class FileLogger : ILogger
    {
        private string path = AppDomain.CurrentDomain.BaseDirectory + "/log.txt";
        public void Log(string msg)
        {
            using (StreamWriter write = new StreamWriter(path, true))
            {
                DateTime date = DateTime.Now;
                write.WriteLine($"{date}\n {msg}");
            }
        }
    }
}