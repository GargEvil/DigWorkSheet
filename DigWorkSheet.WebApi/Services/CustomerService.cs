using AutoMapper;
using DigWorkSheet.Model.Requests;
using DigWorkSheet.WebApi.Database;
using Microsoft.EntityFrameworkCore;
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

        
        public async Task<List<Model.Customer>> Get(CustomerSearchRequest request)
        {
            var query = _context.Customers.AsQueryable();

            if(!string.IsNullOrWhiteSpace(request?.Search))
            {
                query = query.Where(x => x.FirstName.Contains(request.Search) 
                || x.LastName.Contains(request.Search) 
                || x.City.Contains(request.Search)
                || x.Adress.Contains(request.Search));
            }

            

            var list = await query.ToListAsync();

            return await Task.FromResult(_mapper.Map<List<Model.Customer>>(list));
        }

        public Model.Customer Insert(Model.Customer customer)
        {
           
            var account = AccountService.CreateAccountForCustomer(customer);
            var customerEntity = _mapper.Map<Database.Customer>(customer);           

            var accountEntity = _mapper.Map<Account>(account);

            customerEntity.Account = accountEntity;

            _context.Accounts.Add(accountEntity);
            _context.Customers.Add(customerEntity);
            _context.SaveChanges();

            return _mapper.Map<Model.Customer>(customerEntity);
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

        public List<Model.Customer> Delete(int id)
        {
            var entity = _context.Customers.Find(id);

            _context.Remove(entity);
            _context.SaveChanges();

            var list = _context.Customers.ToList();

            return _mapper.Map<List<Model.Customer>>(list);
        }

        public List<Model.Customer> GetByName(string customerName)
        {
            var customers = _context.Customers.Where(c => c.FirstName.Contains(customerName) || c.LastName.Contains(customerName)).ToList();

            return _mapper.Map<List<Model.Customer>>(customers);
        }
    }
}
