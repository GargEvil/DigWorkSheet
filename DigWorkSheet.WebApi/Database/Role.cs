using System;
using System.Collections.Generic;

#nullable disable

namespace DigWorkSheet.WebApi.Database
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
