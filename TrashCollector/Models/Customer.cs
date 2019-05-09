using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Select Employee or Customer")]
        [ForeignKey("applicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }


        [ForeignKey("PickUpDay")]
        public int PickUpDayId { get; set; }
        public PickUpDay PickUpDay { get; set; }
        public IEnumerable <PickUpDay> PickUpDays { get; set;}
    

        public string DayOfWeek { get; set; }

        public bool PickUpComplete { get; set; }
        public string CustomPickUp { get; set; }
        public string PickUpStart { get; set; }
        public string PickUpEnd { get; set; }
        public int CustomerBill { get; set; }

    }
}