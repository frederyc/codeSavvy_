using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeId);
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> GetEmployee(string email);
        Task<Employee> UpdateEmployee(int employeeId, Employee employee);
    }
}
