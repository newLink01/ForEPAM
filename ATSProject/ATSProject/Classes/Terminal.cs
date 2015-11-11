using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
   public class Terminal : ITerminal
    {


       public event EventHandler<PhoneNumber> BeginCall;
       public event EventHandler EndCall;
       public event EventHandler Plugging;
       public event EventHandler UnPlugging;

       private readonly string UserName { set; get; }
       private PhoneNumber Number { get; set; }

       public Terminal(PhoneNumber number,string name) {
           this.Number = number;
           this.UserName = name;
       }

       PhoneNumber ITerminal.Number
       {
           get { throw new NotImplementedException(); }
       }

       public void Call(PhoneNumber target)
       {
           this.OnBeginCall(target);
       }
       public void Drop()
       {
           this.OnEndCall();
       }
       public void Answer()
       {
           throw new NotImplementedException();
       }
       public void Plug()
       {
           this.OnPlugging();
       }
       public void Unplug()
       {
           this.OnUnPlugging();
       }



       protected virtual void OnBeginCall(PhoneNumber e);
       protected virtual void OnEndCall() {
           if (this.EndCall != null) {
               this.EndCall(this,null);
           }
       }
       protected virtual void OnPlugging() {
           if (this.Plugging != null) { Plugging(this,null); }
       }
       protected virtual void OnUnPlugging() {
           if (this.UnPlugging != null) { UnPlugging(this,null); }
       }


    }
}
