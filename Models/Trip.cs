using BRTS_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRTS_System.Models
{
    public class Trip
    {
        [Key]
        public int TripID { set; get; }
        [Required]
        public string Destination { set; get; }

        [Required]
        [DataType(DataType.Date)]

        public string EndData { set; get; }

        [Required]
        [DataType(DataType.Date)]
        public string StartData { set; get; }

        public string BusNumber { get; set; }


        [ForeignKey("AdminId")]//one to many
        public Admin Admin { get; set; }



        public ICollection<User_Trip> User_trip { set; get; }

    }
}
