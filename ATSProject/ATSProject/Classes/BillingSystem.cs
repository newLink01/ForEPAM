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
      public event EventHandler<ITerminal> RequestForGetHistory;

      public List<CallInfo> CallHistory { set; get; }

      public BillingSystem() {
          SW = new StreamWriter("Output.txt");
          CallHistory = new List<CallInfo>();
      }


  

      public void GetBills(HistoryFilter filter)
      {  

          double Cost;
          Func<CallInfo, object> keySelector;

          switch (filter) {
              case HistoryFilter.AbonentName: keySelector = x => x.source.UserName;break;
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



      public void InvokeUpdateCallHistory(CallInfo information) {
          this.OnUpdateCallHistory(information);
      }
      public event EventHandler<CallInfo> UpdateCallHistory;
      protected void OnUpdateCallHistory(CallInfo information) {
          if (this.UpdateCallHistory != null) { this.UpdateCallHistory(this,information); }
      }

      protected void OnRequestForGetHistory(ITerminal terminal) {
          if (this.RequestForGetHistory != null) {
              this.RequestForGetHistory(this, terminal);
          }
      }





    }
}
