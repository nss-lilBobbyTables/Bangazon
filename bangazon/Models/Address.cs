using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StreetName { get; set; }
        public string Zip { get; set; }
        public bool isActive { get; set; }

        public virtual ApplicationUser UserId { get; set; }



    }
}