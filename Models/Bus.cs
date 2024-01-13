using BRTS_System.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRTS_System.Models
{
    [Index(nameof(Bus.captainname), IsUnique = true)]
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Must be insert")]


        public string captainname { set; get; }
        [Required(ErrorMessage = "Must be insert")]



        public int NumberofSeats { set; get; }


        [ForeignKey("AdminID")]
        public Admin Admin { get; set; }



        public ICollection<Trip> trip { set; get; }


    }
}

