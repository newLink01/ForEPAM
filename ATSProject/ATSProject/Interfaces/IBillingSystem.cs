using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Model;
namespace ATSProject.Interfaces
{
   public interface IBillingSystem
    {
       void RequestHistoryBy(ITerminal terminal,HistoryFilter filter);
       bool PayBill(ITerminal terminal);
    }
}
