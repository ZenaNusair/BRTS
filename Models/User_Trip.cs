using BRTS_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRTS_System.Models
{
    public class User_Trip
    {
        [Key]
        public int BookingID { get; set; }

        [ForeignKey("passengerID")]
        public User user { set; get; }

        [ForeignKey("TripId")]
        public Trip trip { set; get; }
    }
}
