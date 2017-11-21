using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bangazon.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Variety { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool LocalDelivery { get; set; }
        public int Rating { get; set; }

        public CategoryType Type { get; set; }

        
        public virtual ApplicationUser CreatedById { get; set; }
        public virtual Cart CartId { get; set; }

    }

    public enum CategoryType
    {
        Appearal,
        Housewares,
        Food,
        Tools,
        Electronics,


    }
}