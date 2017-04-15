using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemOrdered
    {
        public string Name { get; set; }
        public int Place { get; set; }

        public override string ToString()
        {
            return "Name : " + Name + " place : " + Place;
        }
    }
}
