using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Interfaces;

namespace ATSProject.Classes
{
  public class BillingSystem : IBillingSystem
    {
      public List<CallInfo> CallHistory { set; get; }

      public BillingSystem() {
          CallHistory = new List<CallInfo>();

      }


      public void GetBills(){
          //CallHistory.OrderBy(x => x.source.UserName);
          double Cost ;
          foreach (var c in CallHistory.OrderBy(x=>x.source.UserName)) {
              Cost = 0;

              if (c.CurrentRate == Rates.ConstMiddleRate) {
                  Cost = Math.Round(c.duration.TotalMinutes+1) * 50;  
              }

              if (c.CurrentRate == Rates.FirstPartExpensiveAfterFree) {
                  Cost += (Math.Round(c.duration.TotalMinutes/3 + 1)) * 80;
                  Cost += (Math.Round(c.duration.TotalMinutes+1) - (Math.Round(c.duration.TotalMinutes/3 + 1) ) ) * 20;
              }


              Console.WriteLine("\n\nName : " + c.source.UserName + 
                  " \nTargetName : " + c.target.UserName + 
                  "\nBegin call at : " + c.started + "\nDuration : " + c.duration + 
                  "\nCost : " + Cost
                  );
          }


      }





    }
}
