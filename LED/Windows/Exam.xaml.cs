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
        IUC_Exam m_exam = null;

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

            WF_cc_questions.Content = m_waiting;
            Wf_bt_Next.IsEnabled = false;
            Wf_cd_CountDown.OnTimeOut += Wf_cd_CountDown_OnTimeOut;

        }

        private void Wf_bt_Next_Click(object sender, RoutedEventArgs e)
        {

            if (m_exam != null)
           {

                Wf_cd_CountDown.Release();

                if (m_exam.Validate())
                {
                    MessageBox.Show("Bon");
                }
                else
                    MessageBox.Show("Pas bon");

            }

            if (m_view.IsLastQuestion)
            {
                MessageBox.Show("Affichage des résultats !!");
                this.Close();
               
            }
            else
            {
                WF_cc_questions.Content = m_waiting;
                m_view.NextQuestion();

                Wf_bt_Next.IsEnabled = false;
                Wf_bt_start.IsEnabled = true;
            }
        }

        private void Wf_bt_start_Click(object sender, RoutedEventArgs e)
        {
            m_exam = null;

            switch (m_view.CurrentQuestion.TestType)
            {
                case TypeTest.INTRUS:
                    m_exam = new UC_ExamIntrus(m_view.CurrentQuestion.QuestionsIntrus);
                    break;

                case TypeTest.ORDERBY:
                    m_exam = new UC_ExamOrderBy(m_view.CurrentQuestion.QuestionsOrderedBy);
                    break;

                case TypeTest.ORDERED:
                    m_exam = new UC_ExamOrdered(m_view.CurrentQuestion.QuestionsOrdered);
                    break;

                case TypeTest.QCM:
                    m_exam = new UC_ExamQCM(m_view.CurrentQuestion.QuestionsQCM);
                    break;

                case TypeTest.TRUE_FALSE:
                    m_exam = new UC_ExamTrueFalse(m_view.CurrentQuestion.QuestionsTrueFalse);
                    break;

            }

            if (m_exam != null)
            {
                WF_cc_questions.Content = m_exam;

                m_exam.Enabled(true);

                Wf_cd_CountDown.Start(m_view.CurrentQuestion.TimeLimite);
                    
                Wf_bt_Next.IsEnabled = true;
                Wf_bt_start.IsEnabled = false;
            }
            else
                WF_cc_questions.Content = m_waiting;
        }

        private void Wf_cd_CountDown_OnTimeOut()
        {
            m_exam.Enabled(false);
           
            m_view.TimeOut();
        }
    }
}
