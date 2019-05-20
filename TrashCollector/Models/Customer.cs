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

        //[Display(Name = "Select Employee or Customer")]
        [ForeignKey("applicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser applicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "ZipCode")]
        public int ZipCode { get; set; }


        [ForeignKey("PickUpDay")]
        public int PickUpDayId { get; set; }
        public PickUpDay PickUpDay { get; set; }

        public IEnumerable <PickUpDay> PickUpDays { get; set;}

        [Display(Name = "Pick Up Complete")]
        public bool PickUpComplete { get; set; }

        [Display(Name = "Custom Pick Up")]
        [DataType(DataType.Date)]
        public DateTime ? CustomPickUp { get; set; }

        [Display(Name = "Service Start Date")]
        [DataType(DataType.Date)]
        public DateTime ? PickUpStart { get; set; }

        [Display(Name = "Service End Date")]
        [DataType(DataType.Date)]
        public DateTime ? PickUpEnd { get; set; }

        [Display(Name = "Customer Bill")]
        [DataType(DataType.Currency)]
        public float? CustomerBill { get; set; }

    }
}