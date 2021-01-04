using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public interface ICustomerService
    {
         List<Model.Customer> Get();

        Model.Customer Insert(Model.Customer customer);
    }
}
