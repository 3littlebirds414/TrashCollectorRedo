using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Select Employee or Customer")]
        [ForeignKey("applicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public string FirstName { get; set; }
        public int ZipCode { get; set; }
        //public string TodaysPickUp { get; set; }

        //[ForeignKey("PickUpDay")]
        //public int PickUpDayId { get; set; }
        //public PickUpDay PickUpDay { get; set; }


    }
}