using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstEF.Models
{
    public class CustomerDTO
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public string Lastname { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }

    }
}