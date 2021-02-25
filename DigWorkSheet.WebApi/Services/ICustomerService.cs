using DigWorkSheet.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public interface ICustomerService
    {
         Task<List<Model.Customer>> Get(CustomerSearchRequest request);

        Model.Customer Insert(Model.Customer customer);

        Model.Customer GetById(int id);

        Model.Customer Update(int id, Model.Customer customer);

        List<Model.Customer> Delete(int id);

        List<Model.Customer> GetByName(string customerName);
    }
}
