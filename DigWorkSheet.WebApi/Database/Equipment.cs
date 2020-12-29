using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentEmployeeWorkSheets = new HashSet<EquipmentEmployeeWorkSheet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfEquipment { get; set; }
        public bool Active { get; set; }
        public int EmployeeId { get; set; }
        public double Price { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<EquipmentEmployeeWorkSheet> EquipmentEmployeeWorkSheets { get; set; }
    }
}
