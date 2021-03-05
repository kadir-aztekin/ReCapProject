using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }

}
//JWT APİYE BAGLANMASI ICIN DOGRULAMA SERVISIDIR YANI APİYE BAGLANMAK ICIN GEREKLI YER
// TOKENOPTİONS DAKI SECURİTYKEY BAGLAN VE ALGORİTMA OLARAK HMACSHA512 KULLAN 
//CREDENTİALS : KULLANICI BILGILERI EMAİL ,SİFRE.AD SOYAD .... 