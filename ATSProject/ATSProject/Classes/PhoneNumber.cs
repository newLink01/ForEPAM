using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject
{
   public struct PhoneNumber
    {
        private readonly string _phoneNumber;
        public string Value
        {
            get { return _phoneNumber; }
        }

        public PhoneNumber(string phoneNumber)
        {
            this._phoneNumber = phoneNumber;
        }

       public static bool operator ==(PhoneNumber obj1,PhoneNumber obj2){
           if(obj1.Value == obj2.Value)return true;
           return false;
       }
       public static bool operator !=(PhoneNumber obj1,PhoneNumber obj2){
            if(obj1.Value!=obj2.Value)return true;
           return false;
       }

       //override == !=
    }
}
