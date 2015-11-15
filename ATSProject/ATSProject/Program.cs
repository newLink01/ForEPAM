using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Model;
using ATSProject.Interfaces;
using System.Threading;

namespace ATSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingSystem bilSys = new BillingSystem();

            Station station = new Station(bilSys);
            station.SetNewTerminalAndPort(new PhoneNumber("11-11-11"), "Петя",TariffPlans.ConstMedium);
            station.SetNewTerminalAndPort(new PhoneNumber("22-22-22"), "Витя",TariffPlans.TenExpensiveAfterFree);
            station.SetNewTerminalAndPort(new PhoneNumber("33-33-33"), "Жека",TariffPlans.TenExpensiveAfterFree);


            
            station[0].Plug();
            station[1].Plug();
            station[2].Plug();


            station[1].Call(new PhoneNumber("11-11-11"));
           // station[2].Call(new PhoneNumber("11-11-11"));

            Thread.Sleep(5500);
            station[0].Drop();

            station[1].PayBill(bilSys);
            station[1].ChangeTariff(TariffPlans.ConstMedium);
            Console.WriteLine();
            Console.ReadKey();

            station[1].Call(new PhoneNumber("33-33-33"));
            Thread.Sleep(1500);
            station[2].Drop();
            Console.ReadKey();

           // station[1].Call(new PhoneNumber("22-22-22"));


            Console.WriteLine();
            Console.WriteLine();
       

            station[1].GetCallHistoryBy(HistoryFilter.AbonentName,bilSys);
            
 
            Console.ReadKey();
        }

    }
}
