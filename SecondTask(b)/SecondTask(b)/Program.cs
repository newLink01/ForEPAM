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
 
            //Tasks obj = new Tasks("Input.txt");

            Tasks t = new Tasks(path);

            t.ShowConcordance();


           /* List<KeyValuePair<int, string>> a = new List<KeyValuePair<int, string>>();

            a.Add(new KeyValuePair<int, string>(1, "str"));
            a.Add(new KeyValuePair<int, string>(1, "str"));
            a.Add(new KeyValuePair<int, string>(1, "str"));
            a.Add(new KeyValuePair<int, string>(1, "str"));
            a.Add(new KeyValuePair<int, string>(1, "str"));
            a.Add(new KeyValuePair<int, string>(1, "str"));

            foreach (var c in a) { Console.WriteLine(c.Key); }*/


           
                Console.ReadKey();
        }
    }
}
