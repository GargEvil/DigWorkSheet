using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Package
    {
        public int Id { get; set; }
        public bool CaTv { get; set; }
        public int? InternetId { get; set; }
        public int? ContractId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Internet Internet { get; set; }
    }
}
