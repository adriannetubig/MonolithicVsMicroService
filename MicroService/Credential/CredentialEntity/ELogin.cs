using BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace CredentialEntity
{
    public class ELogin : ENoDelete
    {
        [Key]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
