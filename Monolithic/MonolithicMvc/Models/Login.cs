using BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace MonolithicMvc.Models
{
    public class Login : EBase
    {
        [Key]
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}