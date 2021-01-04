using System;
using System.Collections.Generic;
using System.Text;

namespace DigWorkSheet.Model
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public bool Active { get; set; }
        public int PositionId { get; set; }
        public int ContractId { get; set; }
    }
}
