using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class AccountService
    {
        public static Model.Account CreateAccount(Model.Customer customer)
        {
            Model.Account account = new Model.Account
            {
                UserName = customer.FirstName.ToLower() + '.' + customer.LastName.ToLower(),
                Password = 'p'
            };

            return account;
        }
    }
}
