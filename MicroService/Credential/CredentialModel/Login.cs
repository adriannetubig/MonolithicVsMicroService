using BaseModel;

namespace CredentialModel
{
    public class Login : MNoDelete
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
