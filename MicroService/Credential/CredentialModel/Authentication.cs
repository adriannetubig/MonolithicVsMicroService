using System;

namespace CredentialModel
{
    public class Authentication
    {
        public DateTime Expiration { get; set; }
        public DateTime InvalidBefore { get; set; }
        public string Token { get; set; }
    }
}
