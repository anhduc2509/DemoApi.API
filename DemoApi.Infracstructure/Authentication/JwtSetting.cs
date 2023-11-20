using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Authentication
{
    public class JwtSetting
    {
        public const string SectionString = "JwtSetting";
        public string Secret { get; init; } = null!;
        public int ExpiryMinutes { get; init; }

        public string Issuer { get; init; } = null!;

        public string Audience { get; init; } = null!;
    }
}
