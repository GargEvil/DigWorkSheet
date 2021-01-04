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

        
        public List<Model.Customer> Get()
        {
            var list = _context.Customers.ToList();

            return _mapper.Map<List<Model.Customer>>(list);
        }

        public Model.Customer Insert(Model.Customer customer)
        {
            var entity = _mapper.Map<Database.Customer>(customer);

            _context.Customers.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Customer>(entity);
        }

        public Model.Customer GetById(int id)
        {

            var customer = _context.Customers.Where(c => c.Id == id).Single();

            return _mapper.Map<Model.Customer>(customer);       
        }

        public Model.Customer Update(int id, Model.Customer customer)
        {
            var entity = _context.Customers.Find(id);

            _context.Customers.Attach(entity);
            _context.Customers.Update(entity);

            _mapper.Map(customer, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Customer>(entity);
            
        }
    }
}
