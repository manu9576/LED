using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
{
    public class Test
    {
        public string Name { get; set; }
        public string Observations { get; set; }

        public List<Question> Questions { get; set; }

        public List<Category> TestCategory { get; set; }

        public Test()
        {
            Name = "New test";
            Observations = string.Empty;

            Questions = new List<Question>();
            Questions.Add(new Question());

            TestCategory = new List<Category>();
            TestCategory.Add(new Category( "Internet"));
        }
    }
}
