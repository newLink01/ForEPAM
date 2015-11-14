using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;
using System.IO;

namespace ATSProject.Classes
{
  public class BillingSystem : IBillingSystem
    {
      private StreamWriter SW;
      public List<CallInfo> CallHistory { set; get; }



      public BillingSystem() {
          SW = new StreamWriter("Output.txt");
          CallHistory = new List<CallInfo>();
      }



      public void RequestHistoryHandler(HistoryFilter filter)
      {  

          double Cost;
          Func<CallInfo, object> keySelector;

          switch (filter) {
              case HistoryFilter.AbonentName: keySelector = x => x.target.UserName;break;
              case HistoryFilter.CallDate: keySelector = x => x.started;break;
              case HistoryFilter.CallDuration: keySelector = x => x.duration; break;
              default: keySelector = x => x.source.UserName; break;
          }
          

          foreach (var c in CallHistory.OrderBy(keySelector))
          {
              Cost = 0;


              if (c.CurrentRate == Rates.ConstMiddleRate)
              {
                  Cost = Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes + 1) * 50;
              }


              if (c.CurrentRate == Rates.FirstPartExpensiveAfterFree)
              {
                  Cost += (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes / 3 + 1)) * 80;
                  Cost += (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes + 1) - (Math.Round(ScalingTime.ScalingTimeSpan(c.duration).TotalMinutes / 3 + 1))) * 20;
              }


              Console.WriteLine("\n\nName : " + c.source.UserName +
                  " \nTargetName : " + c.target.UserName +
                  "\nBegin call at : " + c.started + "\nDuration : " + ScalingTime.ScalingTimeSpan(c.duration) +
                  "\nCost : " + Cost
                  );
          }
      }

      public void UpdateBillingSystemHandler(object sender,CallInfo information) {


         /* if (information.source.RequestForHistoryBy == null)
          {
              information.source.RequestForHistoryBy += this.RequestHistoryHandler;
          }*/

          this.CallHistory.Add(information);
      }


    }
}
