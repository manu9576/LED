using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.Models
{
    public class ItemOrdered
    {


        [DisplayName("Element")]
        public string Name { get; set; }

        [DisplayName("Indice")]
        public int Place { get; set; }

        public override string ToString()
        {
            return "Name : " + Name + " place : " + Place;
        }
    }
}
