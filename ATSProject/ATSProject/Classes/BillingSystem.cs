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
          CallHistory.OrderBy(x => x.source.UserName);

          foreach (var c in CallHistory) {
              Console.WriteLine(c.source.UserName + " " + c.target.UserName + " " + c.duration);
          }


      }





    }
}
