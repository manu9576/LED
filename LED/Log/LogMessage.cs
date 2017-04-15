using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Log
{
    internal class LogMessage
    {
        private const int SIZE_DATETIME = 25;

        internal DateTime Date { get; set; }
        internal string Message { get; set; }

        internal static string GetEntete()
        {
            return String.Format("{0,-" + SIZE_DATETIME + "}", "Date Time") + ";Message";
        }

        public override string ToString()
        {
            Message = Message.Replace(Environment.NewLine, Environment.NewLine + new string(' ', SIZE_DATETIME) + ";");

            return String.Format("{0,-" + SIZE_DATETIME + "}", Date.ToString("yyyy-MM-dd HH:mm:ss.f")) + ";" + Message;
        }
    }
}
