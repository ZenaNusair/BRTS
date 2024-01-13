using System.ComponentModel.DataAnnotations;

namespace BRTS_System.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please fill the username")]
        public string username { set; get; }
        [Required(ErrorMessage = "*")]

        public string password { set; get; }
    }
}
