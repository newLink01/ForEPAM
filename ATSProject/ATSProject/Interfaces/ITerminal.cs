using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject.Interfaces
{
  public interface ITerminal
    {
      PhoneNumber Number{get;}
      string UserName { get; }

      void Call(PhoneNumber target);
     // void IncomingRequestFrom(PhoneNumber source);
      void Drop();
      void Answer();
      void Plug();
      void Unplug();

       event EventHandler BeginCall;
       event EventHandler EndCall;
       event EventHandler Plugging;
       event EventHandler UnPlugging;
    }
}
