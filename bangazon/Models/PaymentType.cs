using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool isActive { get; set; }
        public DateTime Exp { get; set; }
        
        public virtual ApplicationUser UserId { get; set; }
    }
}