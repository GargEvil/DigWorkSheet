using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigWorkSheet.Model
{
    public partial class Customer
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int ContractId { get; set; }

        public string Comment { get; set; }

        [Required]
        public int AccountId { get; set; }
    }
}
