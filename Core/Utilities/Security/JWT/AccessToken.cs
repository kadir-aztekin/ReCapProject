using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } //burada dıyoruz kı sana bır zaman verdım sısteme bu zaman kadar kullanabilirsin 
    }
}
//kullanıcı adı ve paralo verecek bizde ona bır token verecegız ve ne zaman sonlanacagını soylecegiz  