using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string PruductName { get; set; }

        public string ProductDescription { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }
    }
}