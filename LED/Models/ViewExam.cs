using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public enum State { Waiting, Answering,QuestionResult, TestResult }

    public class ViewExam : INotifyPropertyChanged
    {

        public string TestName { get; private set; }
        public string TestObservations { get; private set; }
        public State Phase { get; set; }

        private string m_QuestionName;
        public string QuestionName
        {
            get
            {
                return m_QuestionName;
            }
            private set
            {
                SetField(ref m_QuestionName, value);
            }
        }

        private string m_QuestionContextPhrase;
        public string QuestionContextPhrase
        {
            get
            {
                return m_QuestionContextPhrase;
            }
            private set
            {
                SetField(ref m_QuestionContextPhrase, value);
            }
        }

        private int m_QuestionTimeLimite;
        public int QuestionTimeLimite
        {
            get
            {
                return m_QuestionTimeLimite;
            }
            private set
            {
                SetField(ref m_QuestionTimeLimite, value);
            }
        }

        private TypeTest m_QuestionTestType;
        public TypeTest QuestionTestType
        {
            get
            {
                return m_QuestionTestType;
            }
            private set
            {
                SetField(ref m_QuestionTestType, value);
            }
        }

        private List<ItemIntrus> m_QuestionsIntrus;
        public List<ItemIntrus> QuestionsIntrus
        {
            get
            {
                return m_QuestionsIntrus;
            }
            private set
            {
                SetField(ref m_QuestionsIntrus, value);
            }
        }

        private List<ItemOrderBy> m_QuestionsOrderedBy;
        public List<ItemOrderBy> QuestionsOrderedBy
        {
            get
            {
                return m_QuestionsOrderedBy;
            }
            private set
            {
                SetField(ref m_QuestionsOrderedBy, value);
            }
        }

        private List<ItemOrdered> m_QuestionsOrdered;
        public List<ItemOrdered> QuestionsOrdered
        {
            get
            {
                return m_QuestionsOrdered;
            }
            private set
            {
                SetField(ref m_QuestionsOrdered, value);
            }
        }

        private List<ItemQCM> m_QuestionQCM;
        public List<ItemQCM> QuestionsQCM
        {
            get
            {
                return m_QuestionQCM;
            }
            private set
            {
                SetField(ref m_QuestionQCM, value);
            }
        }

        private List<ItemTrueFalse> m_QuestionTrueFalse;
        public List<ItemTrueFalse> QuestionsTrueFalse
        {
            get
            {
                return m_QuestionTrueFalse;
            }
            private set
            {
                SetField(ref m_QuestionTrueFalse, value);
            }
        }

        public Question CurrentQuestion
        {
            get
            {
                return m_test.Questions[m_indiceQuestion];
            }
        }


        private Test m_test = null;
        private int m_indiceQuestion = 0;

        private string m_TextTimeLimite;
        public string TextTimeLimite
        {
            get
            {
                return m_TextTimeLimite;
            }

            private set
            {
                SetField(ref m_TextTimeLimite, value);
            }
        }


        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value,[CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public ViewExam()
        {
            m_test = null;
            m_indiceQuestion = 0;

            TestName = "Nom par défaut";
            TestObservations = "Obsevations";

            QuestionName = "Nom de la question";
            QuestionContextPhrase = "Phrase de contexte";
            QuestionTimeLimite = -1;
            QuestionTestType = TypeTest.INTRUS;


            QuestionsIntrus = new List<ItemIntrus>();
            QuestionsOrderedBy = new List<ItemOrderBy>();
            QuestionsOrdered = new List<ItemOrdered>();
            QuestionsQCM = new List<ItemQCM>();
            QuestionsTrueFalse = new List<ItemTrueFalse>();


            TextTimeLimite = "Limite de temps";


        }

        public ViewExam(Test test)
        {
            m_test = test;
            m_indiceQuestion = 0;

            TestName = m_test.Name;
            TestObservations = m_test.Observations;

            if (m_test.Questions.Count > 0)
            {
                ReadCurrentQuestion();
            }
        }


        internal void TimeOut()
        {
            TextTimeLimite = "Temps écoulé.";
        }

        private void ReadCurrentQuestion()
        {
            Phase = State.Waiting;

            QuestionName = m_test.Questions[m_indiceQuestion].Name;
            QuestionContextPhrase = m_test.Questions[m_indiceQuestion].ContextPhrase;
            QuestionTimeLimite = m_test.Questions[m_indiceQuestion].TimeLimite;
            QuestionTestType = m_test.Questions[m_indiceQuestion].TestType;

            QuestionsIntrus = m_test.Questions[m_indiceQuestion].QuestionsIntrus;
            QuestionsOrderedBy = m_test.Questions[m_indiceQuestion].QuestionsOrderedBy;
            QuestionsOrdered = m_test.Questions[m_indiceQuestion].QuestionsOrdered;
            QuestionsQCM = m_test.Questions[m_indiceQuestion].QuestionsQCM;
            QuestionsTrueFalse = m_test.Questions[m_indiceQuestion].QuestionsTrueFalse;
            

            if (QuestionTimeLimite != 0)
            {
                TextTimeLimite = "Limte de temps : " + QuestionTimeLimite + " s.";
            }
            else
            {
                TextTimeLimite = "Pas de limite de temps";
                
            }
        }

        public bool IsLastQuestion
        {
            get
            {
                return m_indiceQuestion+1 >= m_test.Questions.Count;
            }
        }

        public void NextQuestion()
        {
            if(!IsLastQuestion)
            {
                m_indiceQuestion++;
                ReadCurrentQuestion();
            }
        }

    }
}
