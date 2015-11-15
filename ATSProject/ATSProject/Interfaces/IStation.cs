using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Model;

namespace ATSProject.Interfaces
{
   public interface IStation
    {
       event EventHandler<CallInfo> UpdateBillingSystem;
       void SetNewTerminalAndPort(PhoneNumber number, string name, TariffPlans tariff);


    }
}
