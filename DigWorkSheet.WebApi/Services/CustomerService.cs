using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerService(DigWorkSheetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Use AutoMapper
        public List<Model.Customer> Get()
        {
            var list = _context.Customers.ToList();

            return _mapper.Map<List<Model.Customer>>(list);
        }
    }
}
