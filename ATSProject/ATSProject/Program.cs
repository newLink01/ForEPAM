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
            Station st = new Station();
            st.SetNewTerminalAndPort(new PhoneNumber("11-11-11"), "Петя");
            st.SetNewTerminalAndPort(new PhoneNumber("22-22-22"), "Витя");
            st.SetNewTerminalAndPort(new PhoneNumber("33-33-33"), "Жека");


            st.ShowTerminalsAndPorts();
            st.mapping[0].Key.Plug();
            st.mapping[1].Key.Plug();
            st.mapping[2].Key.Plug();

            st.mapping[0].Key.Call(new PhoneNumber("22-22-22"));
            st.mapping[2].Key.Call(new PhoneNumber("22-22-22"));


            Thread.Sleep(3000);
            st.mapping[0].Key.Drop();

            Console.WriteLine();
            Console.WriteLine();

            st.GetHistory();


           
          
            Console.ReadKey();
        }

    }
}
