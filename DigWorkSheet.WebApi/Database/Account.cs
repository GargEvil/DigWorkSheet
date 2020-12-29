using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Account
    {
        public Account()
        {
            Administrators = new HashSet<Administrator>();
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
