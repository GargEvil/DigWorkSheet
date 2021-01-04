using DigWorkSheet.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigWorkSheet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;

        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public List<Model.Employee> Get()
        {
            return _employee.Get();
        }

        [HttpGet("{id}")]
        public Model.Employee GetById(int id)
        {
            return _employee.GetById(id);
        }

        [HttpPost]
        public Model.Employee Insert(Model.Employee employee)
        {
            return _employee.Insert(employee);
        }

        [HttpPut]
        public Model.Employee Update(Model.Employee employee, int id)
        {
            return _employee.Update(id, employee);
        }

        [HttpDelete("{id}")]
        public List<Model.Employee> Delete(int id)
        {
            return _employee.Delete(id);
        }
    }
}
