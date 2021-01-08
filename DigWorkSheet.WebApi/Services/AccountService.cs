using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class AccountService
    {
        public static Model.Account CreateAccountForCustomer(Model.Customer customer)
        {
     
            Model.Account account = new Model.Account
            {

                RoleId = 3,
                UserName = customer.FirstName.ToLower() + '.' + customer.LastName.ToLower(),
                Password = 'p'
            };

            return account;
        }

        public static Model.Account CreateAccountForEmployee(Model.Employee employee)
        {

            Model.Account account = new Model.Account
            {

                RoleId = 2,
                UserName = employee.FirstName.ToLower() + '.' + employee.LastName.ToLower(),
                Password = 'p'
            };

            return account;
        }

        //public static Model.Account CreateAccountForAdmin(Model.Administrator admin)
        //{

        //    Model.Account account = new Model.Account
        //    {

        //        RoleId = 2,
        //        UserName = admin.FirstName.ToLower() + '.' + admin.LastName.ToLower(),
        //        Password = 'p'
        //    };

        //    return account;
        //}
    }
}
