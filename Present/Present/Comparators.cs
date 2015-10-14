using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Present
{
     class Comparator<material> : IComparer<material> where material:ISweet {
         
         static public int Compare(material obj1, material obj2) {
             return obj1.Weight.CompareTo(obj2.Weight);
         }
        


    }
}
