using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExamQCM
    {
        public List<ItemQCM> Questions { get; set; }
        public List<ItemQCM> Answers { get; set; }


        public ViewExamQCM()
        {
            Questions = new List<ItemQCM>() { new ItemQCM { Phrase = "exemple question" } };
            Answers = new List<ItemQCM>() { new ItemQCM { Phrase = "exemple repnose" , IsTrue = true} };
        }

        public ViewExamQCM(List<ItemQCM> question)
        {
            Answers = question;


            Questions = new List<ItemQCM>();

            foreach(ItemQCM item in Answers)
            {
                Questions.Add(new ItemQCM { Phrase = item.Phrase, IsTrue = false });
            }
        }

        internal bool Validate()
        {
            foreach (ItemQCM answer in Answers)
            {
                ItemQCM question = Questions.Find(q => q.Phrase == answer.Phrase);

                if (question == null || question.IsTrue != answer.IsTrue)
                    return false;
            }

            return true;
        }


    }
}
