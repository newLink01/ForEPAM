using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject
{
   public struct PhoneNumber : IEquatable<PhoneNumber>
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
       




       public override string ToString()
       {
           return Value;
       }
       public bool Equals(PhoneNumber other)
       {
           return this._phoneNumber == other._phoneNumber;
       }
       public override bool Equals(object obj)
       {
           if (obj is PhoneNumber)
           {
               return this._phoneNumber == ((PhoneNumber)obj)._phoneNumber;
           }
           else
           {
               return false;
           }
       }
       public override int GetHashCode()
       {
           return _phoneNumber.GetHashCode();
       }
    }
}
