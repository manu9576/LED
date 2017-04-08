﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.models
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

        public string Name { get; set; }
    }
}
