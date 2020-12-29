using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Employee
    {
        public Employee()
        {
            Equipment = new HashSet<Equipment>();
            EquipmentEmployeeWorkSheets = new HashSet<EquipmentEmployeeWorkSheet>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public bool Active { get; set; }
        public int PositionId { get; set; }
        public int ContractId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<EquipmentEmployeeWorkSheet> EquipmentEmployeeWorkSheets { get; set; }
    }
}
