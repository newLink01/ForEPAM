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
            StreamReader reader = new StreamReader("Input.txt");
            Separators sep = new Separators();

            Parser p = new Parser("input.txt");

            /*p.Parse();

            foreach (var c in p.textObject) {
                Console.WriteLine(c.LineIndex);
            }  
            */

            p.Parse();
            Console.WriteLine(p.textObject.text.Count);
                Console.ReadKey();
        }
    }
}
