﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LED.UserControls
{
    public interface IUC_Exam
    {
        bool Validate();

        void Enabled(bool etat);
    }
}
