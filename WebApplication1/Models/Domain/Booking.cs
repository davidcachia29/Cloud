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
        public string LanStart { get; set; }
        public string LonStart { get; set; }
        public string LanEnd { get; set; }
        public string LonEnd { get; set; }
        public string Categories { get; set; }
        public bool accepted { get; set; }

        public virtual List<Post> Bookings { get; set; }
    }
}
