using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Code")]
        public string Code { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public decimal StockOnHand { get; set; }
        public decimal Price { get; set; }


    }
}