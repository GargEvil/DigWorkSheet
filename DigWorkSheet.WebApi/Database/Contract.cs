using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Contract
    {
        public Contract()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Internets = new HashSet<Internet>();
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string NumberOfContract { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Internet> Internets { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
