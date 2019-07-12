using System;

namespace CredentialModel
{
    public class JwtTokenSettings
    {
        public DateTime Expiration => DateTime.UtcNow.AddMinutes(ExpiresMinutes);
        public double ExpiresMinutes { get; set; }
        public string[] AllowedOrigins { get; set; }
    }
}
