using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        // Erişim anahtarı
        public string Token { get; set; }
        public DateTime Expiration { get; set; } 
    }
}
