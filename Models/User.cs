using BRTS_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;
//passenger
namespace BRTS_System.Models
{
    [Index(nameof(User.Username), IsUnique = true)]
    [Index(nameof(User.Email), IsUnique = true)]
    [Index(nameof(User.PhoneNumber), IsUnique = true)]

    public class User
    {
        [Key]
        public int ID { set; get; }

        public string name { set; get; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Should Be insert")]
        [StringLength(50)]
        public string password { set; get; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Gender { get; set; }

        public ICollection<User_Trip> user_trip { set; get; }


    }
}
