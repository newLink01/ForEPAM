using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
   public class Terminal : ITerminal,IShouldClearEvents
    {
      

       public event EventHandler<PhoneNumber> OutgoingConnection;
       public event EventHandler EndCall;
       public event EventHandler Plugging;
       public event EventHandler UnPlugging;
       public event EventHandler IncomingRequest;
       public event EventHandler InitAnswer;


       public string UserName {  set;get; }
       public PhoneNumber Number { set;get; }
       public TariffPlans CurrentRate { set; get; }
       public DateTime DateOfTariffChange { set; get; }

       public Terminal(PhoneNumber number,string name,TariffPlans rate) {
           this.Number = number;
           this.UserName = name;
           this.CurrentRate = rate;
           this.DateOfTariffChange = DateTime.Now;
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
           OnInitAnswer();
       }
       public void Plug()
       {
           this.OnPlugging();
       }
       public void Unplug()
       {
           this.OnUnPlugging();
       }
       public void IncomingRequestFrom() {
           this.OnIncomingRequest();

       }


       public void ClearAllEvents() {
           OutgoingConnection = null;
           EndCall = null;
           Plugging = null;
           UnPlugging = null;
           IncomingRequest = null;
           InitAnswer = null;
       }

       public bool ChangeRate(TariffPlans rate) {

           if (DateTime.Now > (this.DateOfTariffChange))
           {
               this.CurrentRate = rate;
               return true;
           }
           return false;
       }

       
       public void GetCallHistoryBy(HistoryFilter filter,BillingSystem BS) {
           BS.RequestHistoryBy(this,filter);
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
       protected virtual void OnIncomingRequest() {
           if (this.IncomingRequest != null) { this.IncomingRequest(this,null); }
       }
       protected virtual void OnInitAnswer() {
           if (this.InitAnswer != null) { InitAnswer(this,null); }
       }
     



    }
}
