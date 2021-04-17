using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Omegapoint
{
    internal class Logger
    {
        public void WriteLog(string s, string validationFail)
        {
            //Path of LogFile
            var _solutionDirecoty = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            string _logFilePath = Path.Combine(_solutionDirecoty.FullName, "Log.txt");
            //To make sure Dispose is called I use "using" statement
            using (StreamWriter _sw = new StreamWriter(_logFilePath, true))
            {
                _sw.WriteLine(DateTime.Now + " : Failed " + validationFail + " on string " + '"' + s + '"' );
            }
        }
    }
}
