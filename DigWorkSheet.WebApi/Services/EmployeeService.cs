using AutoMapper;
using DigWorkSheet.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DigWorkSheetContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(DigWorkSheetContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Employee> Delete(int id)
        {
            var entity = _context.Employees.Find(id);

            _context.Remove(entity);
            _context.SaveChanges();

            var list = _context.Employees.ToList();

            return _mapper.Map<List<Model.Employee>>(list);
        }

        public List<Model.Employee> Get()
        {
            var list = _context.Employees.ToList();

            return _mapper.Map<List<Model.Employee>>(list);
        }

        public Model.Employee GetById(int id)
        {
            var employeeInDb = _context.Employees.Where(e => e.Id == id).Single();

            return _mapper.Map<Model.Employee>(employeeInDb);

        }

        public Model.Employee Insert(Model.Employee employee)
        {
            var entity = _mapper.Map<Database.Employee>(employee);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Employee>(employee);
        }

        public Model.Employee Update(int id, Model.Employee employee)
        {
            var entity = _context.Employees.Find(id);

            _context.Employees.Attach(entity);
            _context.Employees.Update(entity);

            _mapper.Map(employee, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Employee>(entity);
        }
    }
}
