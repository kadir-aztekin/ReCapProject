using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message):base(false,message)
        {
            //eğer yanlıssa mesajı yaz ve base de (message,false) olana gonder 
        }
        public ErrorResult():base(false)
        {
            //eğer yanlıssa dırek false ı base olan (false) e gönder
        }
    }
}
