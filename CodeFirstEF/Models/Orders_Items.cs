using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class Orders_Items
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Quality { get; set; }
        public decimal Price { get; set;  }
        public decimal Amount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}