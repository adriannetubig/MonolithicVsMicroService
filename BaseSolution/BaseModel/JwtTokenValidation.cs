using System;

namespace BaseModel
{
    //This will be used per web server
    public class JwtTokenValidation
    {
        public double ClockSkewMinutes { get; set; }
        public string IssuerSigningKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public TimeSpan ClockSkew => TimeSpan.FromMinutes(ClockSkewMinutes);
    }
}
