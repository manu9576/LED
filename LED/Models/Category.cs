using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class Category
    {
        public Category()
        {
            Name = "Nouvelle catégorie";
        }

        public Category(string name)
        {
            Name = name;
        }

        [DisplayName("Nom")]
        public string Name { get; set; }
    }
}
