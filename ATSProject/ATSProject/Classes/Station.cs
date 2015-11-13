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

      private List<CallInfo> connectionCollection; // для соединений текущих
      public List<KeyValuePair<ITerminal, IPort>> mapping;
      public List<CallInfo> history;

       public Station() {
           history = new List<CallInfo>();
           this.mapping = new List<KeyValuePair<ITerminal, IPort>>();
           this.connectionCollection = new List<CallInfo>();
       }




       public void SetNewTerminalAndPort(PhoneNumber number,string name) {
           ITerminal obj = new Terminal(number, name);

           obj.OutgoingConnection += this.OutgoingConnectionHandler;
           obj.IncomingRequest += this.IncomingRequestFromHandler;
           obj.Plugging += this.PluggingHandler;
           obj.UnPlugging += this.UnPluggingHandler;
           obj.EndCall += this.EndCallHandler;
           obj.InitAnswer += this.AnswerHandler;

           mapping.Add(new KeyValuePair<ITerminal,IPort>(obj,new Port()));

           }





       private IPort GetPortByPhoneNumber(PhoneNumber obj) {

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Value;
       }
       private ITerminal GetTerminalByPhoneNumber(PhoneNumber obj){

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Key;
          
       }






       private void OutgoingConnectionHandler(object t,PhoneNumber targetPhone) {

           if (t is ITerminal)
           {
               ITerminal sender = t as Terminal;

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
       private void IncomingRequestFromHandler(object o,EventArgs e) {
           
           if (o is ITerminal)
           {
               ITerminal obj = o as Terminal;
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
               ITerminal t = o as Terminal;

               this.connectionCollection.FirstOrDefault(x => x.target.Number.Value == t.Number.Value).started = DateTime.Now;
               Console.WriteLine("Call accepted.");
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
               ITerminal t = o as Terminal;
               this.GetPortByPhoneNumber(t.Number).State = PortState.Free;
           }
       }
       public void UnPluggingHandler(object o, EventArgs e) {
           ITerminal t = o as Terminal;
           this.GetPortByPhoneNumber(t.Number).State = PortState.UnPlagged;
       }





       public void EndCallHandler(object o,EventArgs p) {

           if (o is ITerminal)
           {
               ITerminal t = o as ITerminal;
               var ci = this.connectionCollection.FirstOrDefault(x => x.source.Number.Value == t.Number.Value || x.target.Number.Value == t.Number.Value);

               if (ci != null)
               {
                   this.GetPortByPhoneNumber(ci.target.Number).State = PortState.Free;
                   this.GetPortByPhoneNumber(ci.source.Number).State = PortState.Free;
                   ci.duration = DateTime.Now - ci.started;
                   this.history.Add(ci);
                   this.connectionCollection.Remove(ci);
               }

               if (ci == null)
                   Console.WriteLine("null");
           }
       }



       public void GetHistory() {
           foreach (var c in this.history) {
               Console.WriteLine(c.source.UserName + 
                   ",\n " + c.source.Number.Value + " ,\n " + 
                   c.target.Number.Value + " ,\n Started: " + c.started + 
                   " ,\n Duration: " + c.duration
                   ); 

           }
       }




       }
    }

