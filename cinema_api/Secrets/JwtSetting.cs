using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Cinéma.Secrets
{
    public class JwtSetting
    {
        
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int ExpirationInDays { get; set; }
    }
}
