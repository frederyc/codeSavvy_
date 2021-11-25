using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _db;

        public EmployeeRepository(DatabaseContext db)
        {
            _db = db;
        }

        public Task<Employee> CreateEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return Task.FromResult(employee);
        }

        public Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee = GetEmployee(employeeId).Result;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return Task.FromResult(employee);
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            var employee = _db.Employees.Find(employeeId);
            return Task.FromResult(employee);
        }

        public Task<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            employee.Id = employeeId;
            _db.Employees.Update(employee);
            _db.SaveChanges();
            return Task.FromResult(employee);
        }
    }
}
