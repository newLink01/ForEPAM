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


      public void GetBills(){  //переделать на использование ScalingTime
          

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

      public void InvokeUpdateCallHistory(CallInfo information) {
          this.OnUpdateCallHistory(information);
      }
      public event EventHandler<CallInfo> UpdateCallHistory;
      protected void OnUpdateCallHistory(CallInfo information) {
          if (this.UpdateCallHistory != null) { this.UpdateCallHistory(this,information); }
      }




    }
}
