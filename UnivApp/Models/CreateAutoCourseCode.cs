using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnivApp.Models
{
    public static class CreateAutoCourseCode
    {
        //public static string PreparedCourseCode;

        public static string Create()
        {
            Random random = new Random();
            var randomNumberInt = random.Next(100, 500);
            randomNumberInt++;
            var randomNumberString = randomNumberInt.ToString();

            string output  ="TBML-" + randomNumberString;
            
                return output;
        }

    }
}