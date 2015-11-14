using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Classes;
namespace ATSProject.Interfaces
{
   public interface IBillingSystem
    {
       List<CallInfo> CallHistory { set; get; }
       void GetBills(HistoryFilter filter);
       void InvokeUpdateCallHistory(CallInfo information);

       event EventHandler<CallInfo> UpdateCallHistory;
       event EventHandler<ITerminal> RequestForGetHistory;


    }
}
