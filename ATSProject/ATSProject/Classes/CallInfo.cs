using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;
namespace ATSProject.Classes
{
   public class CallInfo
    {
     public ITerminal source;
     public ITerminal target;
     public DateTime started;
     public TimeSpan duration;

    }
}
