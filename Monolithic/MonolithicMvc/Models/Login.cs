using BaseEntity;

namespace MonolithicMvc.Models
{
    public class Login : EBase
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}