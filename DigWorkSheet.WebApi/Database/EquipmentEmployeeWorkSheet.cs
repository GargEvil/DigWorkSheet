using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class EquipmentEmployeeWorkSheet
    {
        public int Id { get; set; }
        public int WorkSheetId { get; set; }
        public int EquipmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual WorkSheet WorkSheet { get; set; }
    }
}
