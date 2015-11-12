using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
   public class Station : IStation
    {

      private List<CallInfo> callCollection;//для текущих разговоров
      private List<CallInfo> connectionCollection; // для соединений 
      public List<KeyValuePair<ITerminal, IPort>> mapping;

       public Station() {
           
           this.callCollection = new List<CallInfo>();
           this.mapping = new List<KeyValuePair<ITerminal, IPort>>();
           this.connectionCollection = new List<CallInfo>();
       }




       public void SetNewTerminalAndPort(PhoneNumber number,string name) {
           ITerminal obj = new Terminal(number, name);

           obj.OutgoingConnection += this.SetCall;
           obj.IncomingRequest += this.IncomingRequestFromHandler;
           obj.Plugging += this.PluggingHandler;
           obj.UnPlugging += this.UnPluggingHandler;
           
           mapping.Add(new KeyValuePair<ITerminal,IPort>(obj,new Port()));



           }




       private IPort GetPortByPhoneNumber(PhoneNumber obj) {

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Value;
       }
       private ITerminal GetTerminalByPhoneNumber(PhoneNumber obj){

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Key;
          
       }






       private void SetCall(object t,PhoneNumber targetPhone) {

        ITerminal sender =  t as Terminal;
          

           if (this.GetPortByPhoneNumber(sender.Number).State == PortState.Free) {
               GetPortByPhoneNumber(sender.Number).State = PortState.Busy;

               ITerminal targetTerminal = this.GetTerminalByPhoneNumber(targetPhone);
               IPort targetPort = this.GetPortByPhoneNumber(targetPhone);

               if (targetPort.State == PortState.Free) {

                   Console.WriteLine();
                   var callInfo = new CallInfo()
                   {
                       source = sender,
                       target = targetTerminal,
                       started = DateTime.Now
                   };
                    //
                   targetTerminal.IncomingRequestFrom(sender.Number);
                   connectionCollection.Add(callInfo);
                    //
               }
               else{
                   Console.WriteLine("Cannot connect to target port.");  
               }

           }
           else {
               Console.WriteLine("Cant connect to your port.Check port settings.");
               return; }


       }



       private void IncomingRequestFromHandler(object o,EventArgs e) {
           ITerminal obj = o as Terminal;

           Console.WriteLine("Select action: \n1)Answer \n2)Drop");
           string p = Console.ReadLine();
           switch (p) {
               case "1": obj.Answer(); break;
               case "2": obj.Drop(); break;
               default: Console.WriteLine(); break;
           }
       }

       private void AnswerHandler(object o,EventArgs e) {
           ITerminal t = o as Terminal;

           IPort port = this.GetPortByPhoneNumber(t.Number);
           port.State = PortState.Busy;
       }


       public void ShowTerminalsAndPorts() {
           foreach (var c in this.mapping) {
               Console.WriteLine(c.Key.Number.Value + " " + c.Value.State);
           }
       }
       public void PluggingHandler(object o , EventArgs e) {
           ITerminal t = o as Terminal;
           this.GetPortByPhoneNumber(t.Number).State = PortState.Free;
       }
       public void UnPluggingHandler(object o, EventArgs e) {
           ITerminal t = o as Terminal;
           this.GetPortByPhoneNumber(t.Number).State = PortState.UnPlagged;
       }


       public void EndCallHandler(object o, CallInfo e) {
           this.GetPortByPhoneNumber(e.target.Number).State = PortState.Free;
           this.GetPortByPhoneNumber(e.source.Number).State = PortState.Free;
           e.duration = DateTime.Now - e.started;
       }




       }
    }

