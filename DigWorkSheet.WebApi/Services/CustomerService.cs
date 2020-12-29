using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DigWorkSheetContext _context;

        public CustomerService(DigWorkSheetContext context)
        {
            _context = context;
        }

        //Use AutoMapper
        public List<Model.Customer> Get()
        {
            var list = _context.Customers.ToList();

            List<Model.Customer> result = new List<Model.Customer>();

            foreach (var item in list)
            {
                result.Add(new Model.Customer()
                {
                    Id=item.Id,
                    FirstName=item.FirstName,
                    LastName=item.LastName,
                    Adress=item.Adress,
                    ContractId=item.ContractId,
                    Comment=item.Comment
                });
            }
            return result;
        }
    }
}
