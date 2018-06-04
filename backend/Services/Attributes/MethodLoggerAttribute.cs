using Cauldron.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Services;
using Common;

namespace Services.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class MethodLoggerAttribute : Attribute, IMethodInterceptor
    {
        public void OnEnter(Type declaringType, object instance, MethodBase methodbase, object[] values)
        {
            DateTime now = DateTime.Now;
            AppendToFile($"{now} Called {methodbase.Name} from {declaringType.Name}..");
        }

        public bool OnException(Exception e)
        {
            AppendToFile($"Exception -> {e.Message}");
            return false;
        }

        public void OnExit()
        {
        }

        private void AppendToFile(string line)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/methodLog.txt";
            using (StreamWriter write = new StreamWriter(path, true))
            {
                write.WriteLine($"\n {line}");
            }
        }
    }
}
