using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAutotests.Helpers
{
    class LogHelpers
    {

        private static string _logFileName = string.Format("{0:yyyymmddhhss}", DateTime.Now);

        private static StreamWriter _streamWriter = null;

        public static void CreateLogFile()
        {
            string dir = @"..\Log\";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            _streamWriter = File.AppendText(dir + _logFileName + ".log");
        }

        public static void Write(string logMessage)
        {
            _streamWriter.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamWriter.Write(" {0}", logMessage);
            _streamWriter.Flush();
        }

    }
}
