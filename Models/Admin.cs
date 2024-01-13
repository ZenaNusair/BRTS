
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BRTS_System.Models
{
    [Index(nameof(Admin.username), IsUnique = true)]
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string name { set; get; }
        [Required]
        public string username { set; get; }
        [Required]
        public string password { set; get; }
        [Required]
        public string FullName { get; set; }

        public ICollection<Bus> bus { set; get; }
        public ICollection<Trip> trip { get; set; }

    }
}
