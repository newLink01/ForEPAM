using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSProject.Classes;
using ATSProject.Interfaces;
using System.Threading;

namespace ATSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BillingSystem bilSys = new BillingSystem();

            Station st = new Station(bilSys);
            st.SetNewTerminalAndPort(new PhoneNumber("11-11-11"), "Петя",Rates.ConstMiddleRate);
            st.SetNewTerminalAndPort(new PhoneNumber("22-22-22"), "Витя",Rates.FirstPartExpensiveAfterFree);
            st.SetNewTerminalAndPort(new PhoneNumber("33-33-33"), "Жека",Rates.FirstPartExpensiveAfterFree);


            
            st.mapping[0].Key.Plug();
            st.mapping[1].Key.Plug();
            st.mapping[2].Key.Plug();
            st.ShowTerminalsAndPorts();
            st.mapping[0].Key.Call(new PhoneNumber("22-22-22"));
           // st.mapping[2].Key.Call(new PhoneNumber("22-22-22"));


            Thread.Sleep(1000);
            st.mapping[0].Key.Drop();
            
            //bilSys.InvokeUpdateCallHistory();
            //st.mapping[2].Key.Call(new PhoneNumber("22-22-22"));
          //  st.mapping[2].Key.Drop();
            Console.WriteLine();
            Console.WriteLine();
         //   st.mapping[1].Key.Call(new PhoneNumber("33-33-33"));
         //   Thread.Sleep(4000);
           // st.mapping[1].Key.Drop();
            bilSys.RequestHistoryHandler(HistoryFilter.CallDuration);
          
            


          

            
          

            Console.ReadKey();
        }

    }
}
