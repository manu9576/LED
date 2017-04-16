
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LED.Models
{
   public class Bareme
    {
        [DisplayName("Catégorie")]
        public Category Category { get; set; }

        public int Points { get; set; }

        public override string ToString()
        {
            return "Category name : " + Category.Name + " points = " + Points;
        }
    }
}