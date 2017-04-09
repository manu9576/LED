using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class Test
    {
        private List<Category> m_testCategory;

        public string Name { get; set; }
        public string Observations { get; set; }

        public List<Question> Questions { get; set; }

        public List<Category> TestCategory
        {
            get
            {
                
                return m_testCategory;
            }
            set
            {
               
                m_testCategory = value;
            }
        }

        /// <summary>
        /// For each question, we need of the list of the categorie of the question
        /// </summary>
        public void UpdateCategory()
        {
            foreach (Category c in m_testCategory)
            {
                foreach (Question q in Questions)
                {
                    IEnumerable<Category> questionCats = q.Notation.Select(n => n.Category);
                    // if list empty, or list without this cat, we add it
                    if (questionCats == null || (questionCats != null && !questionCats.Contains(c)))
                    {
                        q.Notation.Add(new Bareme { Category = c, Points = 0 });
                    }     
                }
            }

            foreach (Question q in Questions)
            {
                IEnumerable<Category> questionCats = q.Notation.Select(n => n.Category);
                // if list empty, or list without this cat, we add it
                List<Bareme> baremes = new List<Bareme>(q.Notation);

                foreach (Bareme bareme in baremes)
                {
                    if (!m_testCategory.Contains(bareme.Category))
                    {
                        q.Notation.Remove(bareme);
                    }
                }
            }

        }

        public Test()
        {
            Name = "New test";
            Observations = string.Empty;

            Questions = new List<Question>();
            Questions.Add(new Question());

            m_testCategory = new List<Category>();
            m_testCategory.Add(new Category( "Internet"));

            UpdateCategory();

        }
    }
}
