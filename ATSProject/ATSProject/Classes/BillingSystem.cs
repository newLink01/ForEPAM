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


        
              foreach (var c in this.CallHistory.Where(x=>x.source.Number.Value == terminal.Number.Value).OrderBy(keySelector))
              {
                  Console.WriteLine("in foreach");

                  Cost = 0;
                  if (c.CurrentTariffPlan == TariffPlans.ConstMedium)
                  {
                      Cost = Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes + 1) * 50;
                  }


                  if (c.CurrentTariffPlan == TariffPlans.FirstPartExpensiveAfterFree)
                  {
                      Cost += (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes / 3 + 1)) * 80;
                      Cost += (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes + 1) - (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes / 3 + 1))) * 20;
                  }


                  Console.WriteLine("\n\nName : " + c.source.UserName +
                      " \nTarget abonent : " + c.target.UserName +
                      "\nBegin call at : " + c.started + "\nDuration : " + ScalingTime.ScalingTimeSpan(c.duration) +
                      "\nTariff plane : " + c.CurrentTariffPlan + 
                      "\nCost : " + Cost
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







    }
}
