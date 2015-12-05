using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Model
{
   public class Station : IStation
    {
        private List<CallInfo> connectionCollection; 
        private List<KeyValuePair<ITerminal, IPort>> mapping;
        public event EventHandler<CallInfo> UpdateBillingSystem;

        
       public Station(BillingSystem obj) {

           if (this.UpdateBillingSystem == null)
           {
               this.UpdateBillingSystem += obj.UpdateBillingSystemHandler;
           }
           this.mapping = new List<KeyValuePair<ITerminal, IPort>>();
           this.connectionCollection = new List<CallInfo>();
       }




       public void SetNewTerminalAndPort(PhoneNumber number,string name,TariffPlans tariff) {
           ITerminal obj = new Terminal(number, name,tariff);

           obj.OutgoingConnection += this.OutgoingConnectionHandler;
           obj.IncomingRequest += this.IncomingRequestFromHandler;
           obj.Plugging += this.PluggingHandler;
           obj.UnPlugging += this.UnPluggingHandler;
           obj.EndCall += this.EndCallHandler;
           obj.InitAnswer += this.AnswerHandler;
           obj.AllowChangeTariff = false;
          

           mapping.Add(new KeyValuePair<ITerminal,IPort>(obj,new Port()));

           }
       private IPort GetPortByPhoneNumber(PhoneNumber obj) {
           return mapping.FirstOrDefault(x => x.Key.Number == obj).Value;
       }
       private ITerminal GetTerminalByPhoneNumber(PhoneNumber obj){

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Key;
          
       }

       public ITerminal this[int index] {
           get { return this.mapping[index].Key; }
       }




       private void OutgoingConnectionHandler(object t,PhoneNumber targetPhone) {

           try
           {
               if (t is ITerminal)
               {
                   ITerminal sender = t as ITerminal;

                   if (this.GetPortByPhoneNumber(sender.Number).State == PortState.Free)
                   {
                       GetPortByPhoneNumber(sender.Number).State = PortState.Busy;

                       ITerminal targetTerminal = this.GetTerminalByPhoneNumber(targetPhone);
                       IPort targetPort = this.GetPortByPhoneNumber(targetPhone);

                       Console.WriteLine("\nCalling from " + sender.UserName + " to " + targetTerminal.UserName);

                       if (targetPort.State == PortState.Free)
                       {
                           targetPort.State = PortState.Busy;
                           Console.WriteLine();
                           var callInfo = new CallInfo()
                           {
                               source = sender,
                               target = targetTerminal,
                               CurrentTariffPlan = sender.CurrentTariff
                           };
                           //
                           connectionCollection.Add(callInfo);
                           targetTerminal.IncomingRequestFrom();
                           //
                       }
                       else
                       {
                           Console.WriteLine("Cannot connect to target port.");
                       }


                   }
                   else
                   {
                       Console.WriteLine("Cant connect to your port.Check port settings.");
                   }

               }
           }
           catch (NullReferenceException ex) { Console.WriteLine("Cannot connect"); }

       }


       private void IncomingRequestFromHandler(object o,EventArgs e) {
           
           if (o is ITerminal)
           {
               ITerminal obj = o as ITerminal;
               Console.WriteLine("Select action by " + obj.UserName + ": \n1)Answer \n2)Drop");
               string p = Console.ReadLine();
               switch (p)
               {
                   case "1": obj.Answer(); break;
                   case "2": obj.Drop(); break;
                   default: Console.WriteLine(); break;
               }
           }
       }
       private void AnswerHandler(object o,EventArgs e) {
           if (o is ITerminal)
           {
               try
               {
                   ITerminal t = o as ITerminal;
                   var info = this.connectionCollection.FirstOrDefault(x => x.target.Number == t.Number);
                   
                   info.Connected = true;
                   info.started = DateTime.Now;
                   info.Paid = false;
                   Console.WriteLine("Call accepted.");
               }
               catch (NullReferenceException ex) {
                   Console.WriteLine("Call is fall.");
               }
                   
           }
       }
       public void ShowTerminalsAndPorts() {
           foreach (var c in this.mapping) {
               Console.WriteLine(c.Key.UserName + " " + c.Key.Number.ToString() + " " + c.Value.State);
           }
       }
       public void PluggingHandler(object o , EventArgs e) {

           if (o is ITerminal)
           {
               ITerminal t = o as ITerminal;

               if (this.GetPortByPhoneNumber(t.Number).State == PortState.Free) { Console.WriteLine("Already plugged."); }
               else this.GetPortByPhoneNumber(t.Number).State = PortState.Free;
           }
       }
       public void UnPluggingHandler(object o, EventArgs e) {
           ITerminal t = o as Terminal;
           this.GetPortByPhoneNumber(t.Number).State = PortState.UnPlugged;
           
       }

       public void EndCallHandler(object o,EventArgs p) {
           if (o is ITerminal)
           {
               ITerminal t = o as ITerminal;
               
               Console.WriteLine("\nEnd call by " + t.UserName );

               var ci = this.connectionCollection.FirstOrDefault(x => x.source.Number.Value == t.Number.Value || x.target.Number.Value == t.Number.Value);


               if (ci != null)
               {
                   this.GetPortByPhoneNumber(ci.target.Number).State = PortState.Free;
                   this.GetPortByPhoneNumber(ci.source.Number).State = PortState.Free;

                   if (ci.Connected == true) { ci.duration = (DateTime.Now - ci.started); }

                   else { ci.duration = new TimeSpan(0, 0, 0, 0, 0); }
                   this.connectionCollection.Remove(ci);
                   this.OnUpdateBillingSystem(ci);
               }

               if (ci == null)
                   Console.WriteLine("null");
           }
       }


       protected void OnUpdateBillingSystem(CallInfo information) {
           if (this.UpdateBillingSystem != null) { this.UpdateBillingSystem(this,information); }
       }
     

      
       }
    }

