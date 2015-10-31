using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondTask_b_.Interfaces;
using SecondTask_b_.Classes;
using System.IO;

namespace SecondTask_b_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Input.txt";
            Tasks t = new Tasks(path);
            t.ShowFirstConcordance();
           //t.ShowSecondConcordance(4);
           // t.Test(2);
            

           
                Console.ReadKey();
        }
    }
}
