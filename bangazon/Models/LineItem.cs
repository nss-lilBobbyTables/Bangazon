using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public virtual Product ProductId { get; set; }
    }
}