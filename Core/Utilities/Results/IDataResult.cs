using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> :IResult
    {
        //I RESULT VERMEMIZIN NEDENI DATA RESULT( SUCCESS,MESSAGES VE LİST DONDURECEK) BU YUZDEN 
        // I RESULT DAN SUCCES VE MESSAGES CEKIYOR 
        T Data { get; }
    }
}
