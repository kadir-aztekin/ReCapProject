    using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message) : this(success)
        {
            //THİS DEMEKTEDEKİ AMACIMIZ BIZIM HER 2 SIDE CALISSIN DEMEK BU METHODDA
            // ALTTAKI METHODDA SADECE DOGRUMU YANLISMI CAGIRIYOR MESAJ YOK 
            //BİZDE BU METOTDAN ALLTAN CEKIYORUZ 
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
