using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Customer
    {
        public Customer()
        {
            WorkSheets = new HashSet<WorkSheet>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AccountId { get; set; }
        public int ContractId { get; set; }
        public string Comment { get; set; }

        public virtual Account Account { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<WorkSheet> WorkSheets { get; set; }
    }
}
