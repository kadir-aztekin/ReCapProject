using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //APİDE Kİ TokenOptions DA OLUSTURDUGMUZ SECURİTYKEY  STRİNG OLARAK TANIMLADIK BİZ BURDADA SECURİTYKEYI TANIMLADIK BYTE DURUMUNA CEVIRIYORUZ     //STRİNG securityKey tokenoptionsdakı key 
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //SİMETRIK VE ASİTMETRIK ANAHTAR :? 
        }
    }
}
