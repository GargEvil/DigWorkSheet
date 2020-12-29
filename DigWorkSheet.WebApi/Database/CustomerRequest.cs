using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class CustomerRequest
    {
        public int CustomerId { get; set; }
        public int RequestId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Request Request { get; set; }
    }
}
