using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;
namespace ATSProject.Model
{
   public class CallInfo : EventArgs
    {
     public ITerminal source;
     public ITerminal target;
     public DateTime started;
     public TimeSpan duration;
     public TariffPlans CurrentTariffPlan;
     public bool Connected;
     public bool Paid;
    }
}
