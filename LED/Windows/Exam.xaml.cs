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
using LED.UserControls;

namespace LED.Windows
{
    /// <summary>
    /// Logique d'interaction pour PassTest.xaml
    /// </summary>
    public partial class Exam : Window
    {
        Test m_test = null;
        ViewExam m_view = null;
        UC_ExamWaiting m_waiting = null;

        public Exam(Test test)
        {
            InitializeComponent();

            m_test = test;
            m_view = new ViewExam(test);

            DataContext = m_view;

            m_waiting = new UC_ExamWaiting()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,

            };

            uc_cc_questions.Content = m_waiting;


        }

        private void Wf_bt_Next_Click(object sender, RoutedEventArgs e)
        {
            if (m_view.IsLastQuestion)
            {
                MessageBox.Show("Affichage des résultats !!");
                this.Close();
            }
            else
            {
                uc_cc_questions.Content = m_waiting;
                m_view.NextQuestion();

            }
        }

        private void Wf_bt_start_Click(object sender, RoutedEventArgs e)
        {
            switch (m_view.CurrentQuestion.TestType)
            {
                case TypeTest.INTRUS:
                    UC_ExamIntrus intrus = new UC_ExamIntrus(m_view.CurrentQuestion.QuestionsIntrus);
                    uc_cc_questions.Content = intrus;
                    break;

                case TypeTest.ORDERBY:
                    UC_ExamOrderBy orderby = new UC_ExamOrderBy(m_view.CurrentQuestion.QuestionsOrderedBy);
                    uc_cc_questions.Content = orderby;
                    break;

                case TypeTest.ORDERED:
                    UC_ExamOrdered ordered = new UC_ExamOrdered(m_view.CurrentQuestion.QuestionsOrdered);
                    uc_cc_questions.Content = ordered;
                    break;

                case TypeTest.QCM:
                    UC_ExamQCM qcm = new UC_ExamQCM(m_view.CurrentQuestion.QuestionsQCM);
                    uc_cc_questions.Content = qcm;
                    break;

                case TypeTest.TRUE_FALSE:
                    UC_ExamTrueFalse trueFalse = new UC_ExamTrueFalse(m_view.CurrentQuestion.QuestionsTrueFalse);
                    uc_cc_questions.Content = trueFalse;
                    break;

                default:
                    uc_cc_questions.Content = m_waiting;
                    break;
            }
        }
    }
}
