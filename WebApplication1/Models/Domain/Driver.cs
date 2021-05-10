using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Domain
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string DriverID { get; set; }
        public int PassangerCapacity { get; set; }
        public string Condition { get; set; }
        public string RegistrationPlate { get; set; }
        public bool WIFI { get; set; }
        public int AirConditioned { get; set; }
        public bool FoodDrink { get; set; }
        public string Url { get; set; }        


        //public virtual List<> Posts { get; set; }
    }
}
