using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class OrderDTO
    {
        [Key]

        public int Id { get; set; }
        public string No { get; set; }
        public string OrderName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public CustomerDTO Customer { get; set; }
        public string Displayname { get; set; }


    }
}