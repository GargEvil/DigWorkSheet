using System;
using System.Collections.Generic;
using System.Text;

namespace DigWorkSheet.Model
{
    public partial class Internet
    {
        public string Name { get; set; }
        public string Speed { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int? ContractId { get; set; }
    }
}
