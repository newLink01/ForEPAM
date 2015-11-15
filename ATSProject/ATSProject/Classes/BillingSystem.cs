using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;
using System.IO;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
  public class BillingSystem : IBillingSystem
    {
      private List<CallInfo> CallHistory { set; get; }
      private Func<CallInfo, object> keySelector;


      public BillingSystem() {
          CallHistory = new List<CallInfo>();
      }
      public void RequestHistoryBy(ITerminal terminal, HistoryFilter filter)
      {

          keySelector = null;
          double Cost;
          switch (filter)
          {
              case HistoryFilter.AbonentName: keySelector = x => x.target.UserName; break;
              case HistoryFilter.CallDate: keySelector = x => x.started; break;
              case HistoryFilter.CallDuration: keySelector = x => x.duration; break;
              default: keySelector = x => x.source.UserName; break;
          }


          Console.WriteLine("\n\t\tHistory by " + filter);
              foreach (var c in this.CallHistory.Where(x=>x.source.Number == terminal.Number).OrderBy(keySelector))
              {

                  Cost = 0;

                  if (c.CurrentTariffPlan == TariffPlans.ConstMedium)
                  {
                      if (c.duration.TotalSeconds == 0) { Cost = 0; }
                      else
                      {
                          Cost = Math.Round(c.duration.TotalSeconds + 1) * 50;
                      }
                  }


                  if (c.CurrentTariffPlan == TariffPlans.TenExpensiveAfterFree)
                  {
                      if (c.duration.TotalSeconds == 0) { Cost = 0; }
                      else
                      {
                          if (c.duration.TotalSeconds < 10)
                          {
                              Cost += Math.Round((c.duration.TotalSeconds + 1)) * 400;
                          }
                          else { Cost += 10 * 400; }
                      }
                  }


                  Console.WriteLine("\n\nName : " + c.source.UserName +
                      " \nTarget abonent : " + c.target.UserName +
                      "\nBegin call at : " + c.started + "\nDuration : " + c.duration +
                      "\nTariff plane : " + c.CurrentTariffPlan + 
                      "\nCost : " + Cost + 
                      "\nPayed : " + c.Paid
 
                      );
                 // return;
              }
              //Console.WriteLine("Such information dont exist."); return;
          }
      public void UpdateBillingSystemHandler(object sender,CallInfo information) {
          if (information != null)
          {
              this.CallHistory.Add(information);
          }
      }

      public bool PayBill(ITerminal terminal) {

          foreach (var c in this.CallHistory.Where(x => x.source.Number == terminal.Number)) {
              if (c.Paid == false) {
                  c.Paid = true;
              }
          }
          return true;
      }






    }
}
