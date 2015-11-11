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
       private EventHandler<PhoneNumber> BeginCallHandler;

       List<CallInfo> callHistory;
       List<KeyValuePair<ITerminal, IPort>> mapping;
       List<CallInfo> callCollection;
      // List<IPort> portCollection;

       public Station() {
           
           this.callCollection = new List<CallInfo>();
           this.callHistory = new List<CallInfo>();
           this.mapping = new List<KeyValuePair<ITerminal, IPort>>();
         //  this.portCollection = new List<IPort>();
       }

       //в функции подписка
       public void SetNewTerminalAndPort(PhoneNumber number,string name) {
           mapping.Add(new KeyValuePair<ITerminal,IPort>(new Terminal(number,name),new Port()));
           }

       private IPort GetPortByPhoneNumber(PhoneNumber obj) {

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Value;
       }
       private ITerminal GetTerminalByPhoneNumber(PhoneNumber obj){

           return mapping.FirstOrDefault(x => x.Key.Number == obj).Key;
          
       }






       private void SetConnection(ITerminal sender,PhoneNumber targetPhone) {
          


           if (this.GetPortByPhoneNumber(sender.Number).State == PortState.Free) {
               GetPortByPhoneNumber(sender.Number).State = PortState.Busy;

               if (this.GetPortByPhoneNumber(targetPhone).State == PortState.Free) { 
                   var callInfo = new CallInfo(){
                        source = sender,
                        target = targetPhone,
                        started = Date
                   }




               }
               else{
                    
               }

           }


           if (this.GetPortByPhoneNumber(sender.Number).State == PortState.UnPlagged || this.GetPortByPhoneNumber(sender.Number).State == PortState.Busy) {
               Console.WriteLine("Cant connect to the your port.Check port settings.");
               return; }
       } 
      





       }








    }

