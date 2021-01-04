using DigWorkSheet.Model;
using System.Collections.Generic;

namespace DigWorkSheet.WebApi.Services
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee GetById(int id);
        Employee Insert(Employee employee);
        Employee Update(int id, Employee employee);
        List<Employee> Delete(int id);


    }
}