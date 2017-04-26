using LED.Log;
using LED.Models;
using System.Windows;

namespace LED.Windows
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestsCollection m_tests = null;


        public MainWindow()
        {
            InitializeComponent();
            m_tests = TestsCollection.GetTests();
            Logger.WriteMessage("Application Start");

            Wf_dg_testsList.DataContext = m_tests.Tests;
        }

        private void Bt_CreateNewTest_Click(object sender, RoutedEventArgs e)
        {
            Logger.WriteMessage("Opening CreateNewTest");

            Test questionnaire = new Test { Name = "Nouveau test" };
            
            EditTest cnt = new EditTest(questionnaire);
            this.Hide();
            cnt.ShowDialog();
            this.Show();

            if (cnt.Validate)
            { 
                m_tests.Tests.Add(questionnaire);
                Wf_dg_testsList.Items.Refresh();
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_tests.Save();
            Logger.Dispose();
        }


        private void Wf_bt_Modify_Click(object sender, RoutedEventArgs e)
        {
            Test testSelectionne = Wf_dg_testsList.SelectedItem as Test;

            if (testSelectionne != null)
            {
                Test questionnaire = new Test(testSelectionne);

                EditTest cnt = new EditTest(questionnaire);

                this.Hide();
                cnt.ShowDialog();
                this.Show();

                if (cnt.Validate)
                {
                    m_tests.Tests.Add(questionnaire);
                    m_tests.Tests.Remove(testSelectionne);
                    Wf_dg_testsList.Items.Refresh();
                }


            }
        }
        

        private void Wf_dg_testsList_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                Test testSelectionne = Wf_dg_testsList.SelectedItem as Test;

                if (testSelectionne != null)
                {
                    Test questionnaire = new Test(testSelectionne);
                    MessageBoxResult res = MessageBox.Show("Confirmez-vous la suppression du test : " + testSelectionne.Name,
                        "Suppression test", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    e.Handled = (res == MessageBoxResult.No);
                    
                }
            }
        }

        private void Wf_bt_StartTest_Click(object sender, RoutedEventArgs e)
        {
            Test testSelectionne = Wf_dg_testsList.SelectedItem as Test;

            if (testSelectionne != null)
            {
                Exam exam = new Exam(testSelectionne);

                this.Hide();
                exam.ShowDialog();
                this.Show();


            }
        }
    }
}
