using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
   public class Port : IPort
    {
       public PortState State
       {
           get;
           set;
       }

       public Port() { State = PortState.UnPlagged; }


        //public event EventHandler<PortState> StateChanging;
     //   public event EventHandler<PortState> StateChanged;
    }
}
