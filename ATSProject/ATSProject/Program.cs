using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValuePair<int, int> p = new KeyValuePair<int, int>(1, 2);
            KeyValuePair<int, int> p1 = new KeyValuePair<int, int>(1, 2);
            KeyValuePair<int, int> p2 = new KeyValuePair<int, int>(2, 2);

            List<KeyValuePair<int, int>> arr = new List<KeyValuePair<int, int>>();
            arr.Add(p);
            arr.Add(p1);
            arr.Add(p2);

            var c = arr.Select(x => x).Where(x => x.Key == 1);

            foreach (var s in c) {
                Console.WriteLine(s.Key + " " + s.Value);
            }

            Console.WriteLine("Its begin");
            Console.ReadKey();
        }

    }
}
