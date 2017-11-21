using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}