using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class WorkSheet
    {
        public WorkSheet()
        {
            EquipmentEmployeeWorkSheets = new HashSet<EquipmentEmployeeWorkSheet>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string DescriptionReportedProblem { get; set; }
        public string DescriptionExecutedWork { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<EquipmentEmployeeWorkSheet> EquipmentEmployeeWorkSheets { get; set; }
    }
}
