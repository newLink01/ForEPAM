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
       public Port() { State = PortState.UnPlugged; }


       /* public event EventHandler<PortState> StateChanging;
        public event EventHandler<PortState> StateChanged;

        protected virtual void OnStateChanging(object sender , PortState newState) {
            if (StateChanging != null) {
                this.StateChanging(this,newState);
            }    

            }
        protected virtual void OnStateChanged(object sender, PortState State) {
            if (StateChanged != null) { StateChanged(sender,State); }
        }
       */
    }
}
