using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DateOpened { get; set; }
        public bool ActiveStatus { get; set; }

        public virtual ApplicationUser UserId { get; set; }
        public virtual List<LineItem> LineItems { get; set; }
        public virtual PaymentType PaymentTypeId { get; set; }
        public virtual Address Address { get; set; }
        
    }
}