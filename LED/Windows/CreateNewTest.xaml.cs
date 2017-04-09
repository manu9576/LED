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
using LED.Models;

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
            m_questionnaire.UpdateCategory();
        }


        private void dg_Categories_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            m_questionnaire.UpdateCategory();
            wf_dg_Notations.Items.Refresh();
        }

        private void dg_Categories_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            m_questionnaire.UpdateCategory();
            wf_dg_Notations.Items.Refresh();
        }

    }
}
