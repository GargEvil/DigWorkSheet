using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Internet
    {
        public Internet()
        {
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int? ContractId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
