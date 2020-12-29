using System;
using System.Collections.Generic;
using System.Text;

namespace DigWorkSheet.Model
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int ContractId { get; set; }
        public string Comment { get; set; }
    }
}
