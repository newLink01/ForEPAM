using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject
{
   public struct PhoneNumber
    {
       private readonly int phoneNumber { get; private set; }

       public PhoneNumber(int PhoneNumber) {
           phoneNumber = PhoneNumber;
       }
    }
}
