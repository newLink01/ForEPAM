using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSProject.Classes
{
   public static class ScalingTime
    {
       public static TimeSpan ScalingTimeSpan(TimeSpan TS)
        {
            return new TimeSpan(0, (int)TS.TotalSeconds  * 5000, 0); // секунды умножаем на 100 и получаем столько минут разговора
        }


       public static DateTime ScalingDateTime(DateTime DT) {


           return new DateTime() ;
       }



    }
}
