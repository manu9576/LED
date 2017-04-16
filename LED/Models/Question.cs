using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    [Flags]
    public enum TypeTest
    { 
        [Display(Name ="QCM")]
        QCM,
        [Display(Name = "Classement")]
        ORDERED,
        [Display(Name = "Classement par conténaires")]
        ORDERBY,
        [Display(Name = "Recherche de l'intrus")]
        INTRUS,
        [Display(Name = "Vrai / faux")]
        TRUE_FALSE
    }

    public enum QuestionStat { UNDONE, GOOD, FALSE }

    public class Question
    {
        [DisplayName("Nom du question")]
        public string Name { get; set; }

        [DisplayName("Phrase d'explication")]
        public string ContextPhrase { get; set; }

        [DisplayName("Temps limite")]
        public int TimeLimite { get; set; }

        [DisplayName("Type de test")]
        public TypeTest TestType { get; set; }

        [DisplayName("Notations de la question")]
        public List<Bareme> Notation { get; set; }

        public QuestionStat State { get; set; }


        public List<ItemIntrus> QuestionsIntrus { get; set; }
        public List<ItemOrderBy> QuestionsOrderedBy { get; set; }
        public List<ItemOrdered> QuestionsOrdered { get; set; }
        public List<ItemQCM> QuestionsQCM { get; set; }
        public List<ItemTrueFalse> QuestionsTrueFalse { get; set; }

        public Question()
        {
            Name = "Question";
            TestType = TypeTest.INTRUS;

            Notation = new List<Bareme>();

            QuestionsIntrus = new List<ItemIntrus>();
            QuestionsOrderedBy = new List<ItemOrderBy>();
            QuestionsOrdered = new List<ItemOrdered>();
            QuestionsQCM = new List<ItemQCM>();
            QuestionsTrueFalse = new List<ItemTrueFalse>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("******* Question name : " + Name + "******");
            sb.AppendLine("** Phrase : " + ContextPhrase);
            sb.AppendLine("** Time limite  = " + TimeLimite);
            sb.AppendLine("** Test type : " + TestType);
            sb.AppendLine("** Notation : ");

            foreach (Bareme bar in Notation)
                sb.AppendLine("****** " + bar);
            sb.AppendLine("** State : " + State);

            sb.AppendLine("** Question : ");

            switch (TestType)
            {
                case TypeTest.ORDERBY:

                    foreach (ItemOrderBy item in QuestionsOrderedBy)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.INTRUS:

                    foreach (ItemIntrus item in QuestionsIntrus)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.ORDERED:

                    foreach (ItemOrdered item in QuestionsOrdered)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.QCM:

                    foreach (ItemQCM item in QuestionsQCM)
                        sb.AppendLine("**\t" + item);
                    break;

                case TypeTest.TRUE_FALSE:

                    foreach (ItemTrueFalse item in QuestionsTrueFalse)
                        sb.AppendLine("**\t" + item);
                    break;

            }

            return sb.ToString();
        }
    }
}
