﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Classes;


namespace ATSProject.Interfaces
{
   public interface IBillingSystem
    {
       List<CallInfo> CallHistory { set; get; }
       


    }
}
