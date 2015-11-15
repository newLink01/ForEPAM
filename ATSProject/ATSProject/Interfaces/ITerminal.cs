using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Classes;
namespace ATSProject.Interfaces
{
  public interface ITerminal
    {
      PhoneNumber Number { get; set; }
      string UserName { get; set; }
      TariffPlans CurrentTariff { get;set; }
      DateTime DateOfTariffChange { get; set; }
      bool AllowChangeTariff { set; get; }

      void Call(PhoneNumber target);
      void Drop();
      void Answer();
      void Plug();
      void Unplug();
      void IncomingRequestFrom();
      bool ChangeTariff(TariffPlans rate);
      void GetCallHistoryBy(HistoryFilter filter,BillingSystem BS);
      bool PayBill(BillingSystem BS);


       event EventHandler<PhoneNumber> OutgoingConnection;
       event EventHandler EndCall;
       event EventHandler Plugging;
       event EventHandler UnPlugging;
       event EventHandler IncomingRequest;
       event EventHandler InitAnswer;

       
     

    }
}
