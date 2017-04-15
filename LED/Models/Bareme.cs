
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LED.Models
{
   public class Bareme
    {
        public Category Category { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return "Category name : " + Category.Name + " points = " + Points;
        }
    }
}