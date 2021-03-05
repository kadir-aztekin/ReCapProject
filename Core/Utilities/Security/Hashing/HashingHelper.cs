using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
        public static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //NEDEN PASSWORDSALT? : ÇÜNKÜ BİZ SİFREYİ OLUSTURDUK VE OLUSTURKEN BIR TUZ OLUSTU AYNI ZAMANDA E BIZ BURDA DOGRULAMA YAPIYORUZ YUKARDA KI SALTI KULLANACAGIZ BAKACAGIZ DATABASE DE BU SALT VARMI EGER VARSA DEVAM ET 
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]  != passwordHash[i])  //EĞER GIRILEN HASH SISTEMDEKI HASH E ESITMI YANİ KISACA KULLANICI SIFRESI ILE
                                                                //SİSTEMDEKİ ŞİFRE AYNIMI TESTTİ 
                    {
                        return false;

                    }
                }
            }
            return true;

        }
    }
}
//HASH OLUSTURMAYA 
// VE HASH DOGRULAMAYA YARAR 