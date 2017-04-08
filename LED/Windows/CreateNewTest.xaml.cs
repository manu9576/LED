using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LED.models;

namespace LED.Windows
{
    /// <summary>
    /// Logique d'interaction pour CreateNewTest.xaml
    /// </summary>
    public partial class CreateNewTest : Window
    {
        private Test m_questionnaire = null;


        public CreateNewTest()
        {
            InitializeComponent();

            m_questionnaire = new Test();
            m_questionnaire.Name = " toto ";
            this.DataContext = m_questionnaire;
           
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(m_questionnaire.Name);
            Console.WriteLine(m_questionnaire.Observations);
            Console.WriteLine(m_questionnaire.Questions.Count);
        }
    }
}
