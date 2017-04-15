using LED.Log;
using LED.Models;
using LED.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

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
            Logger.WriteMessage(m_questionnaire.ToString());
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

        private void dg_Questions_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            m_questionnaire.UpdateCategory();
            wf_dg_Notations.Items.Refresh();
        }

        private void dg_Questions_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            m_questionnaire.UpdateCategory();
            wf_dg_Notations.Items.Refresh();
        }

        private void dg_Questions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualiseDetails();
        }

        private void ActualiseDetails()
        {
            object selection = dg_Questions.SelectedItem;

            try
            {

                if (selection is Question && this.IsActive)
                {
                    Question quest = selection as Question;

                    switch (quest.TestType)
                    {
                        

                        case TypeTest.INTRUS:
                            UC_Intrus intrus = new UC_Intrus();
                            intrus.dg_Question_Intrus.ItemsSource = quest.QuestionsIntrus;
                            gb_details.Content = intrus;
                           break;

                        case TypeTest.BY_TYPE:
                            UC_OrderdBy orderedBy = new UC_OrderdBy();
                            orderedBy.dg_question_orderedBy_Contenaire.ItemsSource = quest.QuestionsOrderedBy;
                            gb_details.Content = orderedBy;
                            break;

                        case TypeTest.ORDERED:
                            UC_Ordered ordered = new UC_Ordered();
                            ordered.dg_question_ordered.ItemsSource = quest.QuestionsOrdered;
                            gb_details.Content = ordered;
                            break;

                        case TypeTest.QCM:
                            UC_QCM qcm = new UC_QCM();
                            qcm.dg_Question_QCM.ItemsSource = quest.QuestionsQCM;
                            gb_details.Content = qcm;
                            break;

                        case TypeTest.TRUE_FALSE:
                            UC_TrueFalse trueFalse = new UC_TrueFalse();
                            trueFalse.dg_question_trufalse.ItemsSource = quest.QuestionsTrueFalse;
                            gb_details.Content = trueFalse;
                            break;

                        default:
                            gb_details.Content = null;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.WriteMessage(ex);
                
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualiseDetails();
        }
    }
}
