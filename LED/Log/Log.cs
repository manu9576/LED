using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LED.Log
{
    public class Logger
    {

        private const string LOG_NAME = "Log.txt";
        private const long MAX_SIZE = 1000000;
        private static Queue<LogMessage> m_Messages = null;
        private static bool m_running = false;
        private static string m_fileName = string.Empty;
        private static Thread m_ThreadWriting = null;

        static Logger()
        {
            try
            {
                m_Messages = new Queue<LogMessage>();
                m_fileName = System.AppDomain.CurrentDomain.BaseDirectory + LOG_NAME;
                m_ThreadWriting = new Thread(Writtring);
                m_ThreadWriting.Name = "Logger Thread";
                m_ThreadWriting.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        public static void Dispose()
        {
            try
            {
                m_running = false;

                if (m_ThreadWriting != null)
                {
                    m_ThreadWriting.Abort();
                    m_ThreadWriting.Join();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        private static void Writtring()
        {
            m_running = true;
            FileInfo fi = new FileInfo(m_fileName);

            while (m_running)
            {
                try
                {
                    if (!fi.Exists)
                    {
                        CreateLog();
                    }
                    else if (fi.Length > MAX_SIZE)
                    {
                        RemaneFile();
                    }

                    if (m_Messages.Count > 0)
                    {
                        using (StreamWriter sw = new StreamWriter(m_fileName, true))
                        {
                            while (m_Messages.Count > 0)
                            {
                                string line = m_Messages.Dequeue().ToString();
                                sw.WriteLine(line);
                                Console.WriteLine(line);
                            }
                        }
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " " + ex.StackTrace);
                }
            }
        }

        private static void RemaneFile()
        {
            try
            {
                string backupFile = m_Messages + ".old";

                if (File.Exists(backupFile))
                    File.Delete(backupFile);

                File.Move(m_fileName, backupFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        private static void CreateLog()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(m_fileName))
                {
                    sw.WriteLine(LogMessage.GetEntete());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        public static void WriteMessage(string message)
        {
            if (m_Messages != null)
                m_Messages.Enqueue(new LogMessage { Date = DateTime.Now, Message = message });
        }

        public static void WriteMessage(Exception ex)
        {
            WriteMessage("ERROR : " + ex.Message + " -- " + ex.StackTrace);
        }

    }
}
