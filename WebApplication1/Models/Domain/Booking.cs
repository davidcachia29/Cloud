using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Domain
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookingID { get; set; }
        public string PassangerName { get; set; }
        public string Location { get; set; }
        public string Categories { get; set; }

        public virtual List<Post> Bookings { get; set; }
    }
}
