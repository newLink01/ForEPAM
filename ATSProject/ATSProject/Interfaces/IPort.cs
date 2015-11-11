using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject.Interfaces
{
   public interface IPort
    {

      PortState State { set; get; }

    //  event EventHandler<PortState> StateChanging;
    //  event EventHandler<PortState> StateChanged;
    }
}
