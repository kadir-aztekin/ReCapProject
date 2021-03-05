using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)
        {
            //eğer dogru ıse kosullarımı message base dedıgımız  result(message ve success) olana gonder 
        }
        public SuccessResult():base(true)
        {
            //eğer dogru ıse base yanı result dakı success olana gonder 
        }

    }
}
