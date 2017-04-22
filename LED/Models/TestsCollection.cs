using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LED.Models
{
    public class TestsCollection
    {
        private const string FILE_NAME = "Tests.xml";

        public List<Test> Tests { get; set; }

        private static string m_fileName = string.Empty;

        private TestsCollection()
        {
            Tests = new List<Test>();
            
        }

        public static TestsCollection GetTests()
        {
            m_fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + FILE_NAME;
            return Load();
        }

        private static TestsCollection Load()
        {
            TestsCollection tests = new TestsCollection();


            if (File.Exists(m_fileName))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TestsCollection));
                    using (TextReader writer = new StreamReader(m_fileName))
                    {
                        tests = serializer.Deserialize(writer) as TestsCollection;
                    }

                }
                catch (Exception ex)
                {
                    Log.Logger.WriteMessage(ex);
                }
            }


            return tests;
        }


        public void Save()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + FILE_NAME;

            XmlSerializer serializer = new XmlSerializer(typeof(TestsCollection));
            using (TextWriter writer = new StreamWriter(m_fileName))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}

