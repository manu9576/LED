using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ViewExamIntrus
    {
        public List<ItemIntrus> Questions { get; set; }
        public List<ItemIntrus> Answers { get; set; }


        public ViewExamIntrus()
        {
            Questions = new List<ItemIntrus>() { new ItemIntrus { Phrase = "exemple question" } };
            Answers = new List<ItemIntrus>() { new ItemIntrus { Phrase = "exemple repnose", IsIntrus = false } };
        }

        public ViewExamIntrus(List<ItemIntrus> question)
        {
            Answers = question;


            Questions = new List<ItemIntrus>();

            foreach (ItemIntrus item in Answers)
            {
                Questions.Add(new ItemIntrus { Phrase = item.Phrase, IsIntrus = false });
            }
        }

        internal bool Validate()
        {
            foreach (ItemIntrus answer in Answers)
            {
                ItemIntrus question = Questions.Find(q => q.Phrase == answer.Phrase);

                if (question == null || question.IsIntrus != answer.IsIntrus)
                    return false;
            }

            return true;
        }

    }
}
