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

        public string City { get; set; }

        [Required]
        public int ContractId { get; set; }

        public string Comment { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
      
    }
}
