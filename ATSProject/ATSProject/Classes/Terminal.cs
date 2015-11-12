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


       public event EventHandler<PhoneNumber> OutgoingConnection;
       public event EventHandler EndCall;
       public event EventHandler Plugging;
       public event EventHandler UnPlugging;
       public event EventHandler<PhoneNumber> IncomingRequest;


       public string UserName { set; get; }
       public PhoneNumber Number { get; set; }

       public Terminal(PhoneNumber number,string name) {
           this.Number = number;
           this.UserName = name;
       }

   

       public void Call(PhoneNumber target)
       {
           this.OnOutgoingConnection(target);
       }
       public void Drop()
       {
           this.OnEndCall();
       }
       public void Answer()
       {

       }
       public void Plug()
       {
           this.OnPlugging();
       }
       public void Unplug()
       {
           this.OnUnPlugging();
       }

       public void IncomingRequestFrom(PhoneNumber source) {
           this.OnIncomingRequest(source);

       }


       protected virtual void OnOutgoingConnection(PhoneNumber e) {
           if (this.OutgoingConnection != null) { OutgoingConnection(this,e); }
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
       protected virtual void OnIncomingRequest(PhoneNumber source) {
           if (this.IncomingRequest != null) { this.IncomingRequest(this,source); }
       }


    }
}
