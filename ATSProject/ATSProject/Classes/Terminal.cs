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
       public event EventHandler<HistoryFilter> RequestForHistoryBy;


       public string UserName { set;get; }
       public PhoneNumber Number { set;get; }
       public Rates CurrentRate { set; get; }
       public DateTime DateOfRateChange { set; get; }

       public Terminal(PhoneNumber number,string name,Rates rate) {
           this.Number = number;
           this.UserName = name;
           this.CurrentRate = rate;
           this.DateOfRateChange = DateTime.Now;
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
           RequestForHistoryBy = null;
       }

       public bool ChangeRate(Rates rate) {

           if (DateTime.Now >= (this.DateOfRateChange))
           {
               this.CurrentRate = rate;
               return true;
           }
           return false;
       }

       
       public void GetCallHistoryBy(HistoryFilter filter) {

           this.OnRequestForHistoryBy(filter);

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
       protected virtual void OnRequestForHistoryBy(HistoryFilter filter) {
           if (this.RequestForHistoryBy != null) { this.RequestForHistoryBy(this,filter); } 

       }



    }
}
