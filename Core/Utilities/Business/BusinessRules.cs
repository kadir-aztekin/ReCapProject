using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    { 
        //RUN : CALISTIR DEMEEK 
        //params  IResult[] logics : params var verdiğimizde istediğimiz kadar ıresult yazarız
        //logic:is kuralı 
        public static IResult Run(params  IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; 

                    //error dondurmedık cunku bız productmanager ıcınde error veya success verdık bu sadece calıs ve gez dıyoruz 
                }
            }
            return null;
        }
    }
}
