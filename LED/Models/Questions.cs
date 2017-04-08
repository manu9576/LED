using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
{
    public enum TypeTest {QCM,ORDERED,BY_TYPE,INTRUS,TRUE_FALSE } 
    public enum QuestionStat { UNDONE, GOOD, FALSE}


    public class Question
    {
        public string Name { get; set; }
        public string ContextPhrase { get; set; }
        public int TimeLimite { get; set; }
        public TypeTest TestType { get; set; }
        public Dictionary<Category,int> Notation { get; set; }
        public QuestionStat State { get; set; }

        List<Item_Intrus> Questions_intrus { get; set; }

        List<Item_OrderBy> Questions_orderedBy { get; set; }

        List<Item_Ordered> Questions_ordered { get; set; }

        List<Item_QCM> Questions_QCM { get; set; }

        List<Item_TrueFalse> Question_vraifaux { get; set; }

        public Question()
        {
            Name = "test1";
            TestType = TypeTest.INTRUS; 

        }
    }
}
