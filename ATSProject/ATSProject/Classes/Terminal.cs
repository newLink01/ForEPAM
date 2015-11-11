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


       public event EventHandler BeginCall;
       public event EventHandler EndCall;
       public event EventHandler Plugging;
       public event EventHandler UnPlugging;

       private PhoneNumber Number { get; set; }
       public Terminal(PhoneNumber number) {
           this.Number = number;
       }



       PhoneNumber ITerminal.Number
       {
           get { throw new NotImplementedException(); }
       }

       public void Call(PhoneNumber target)
       {
           this.OnBeginCall();
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



       protected virtual void OnBeginCall() {
           if (this.BeginCall != null) {
               BeginCall(this, null);
           }
       }
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
