using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Application.Exceptions.NotFoundException;
using CodeSavvy.Application.Exceptions.NullArgumentException;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using CodeSavvy.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CodeSavvy.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _db;

        public EmployeeRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _ = employee ?? throw new EmployeeNullArgumentException();
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {

            var x = await _db.Employees
                                    .Include(x => x.Credentials)
                                    .SingleAsync(x => x.Id == employeeId);
            _db.Employees.Remove(x);
            await _db.SaveChangesAsync();
            return x;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var employee = await _db.Employees.Include(x => x.Credentials).SingleAsync(x => x.Id == employeeId) ??
                           throw new EmployeeNotFoundException($"Employee with Id: {employeeId} could not be found");
            return employee;
        }

        // Returns Employee based on credentials Id
        public async Task<Employee> GetEmployee(string email)
        {
            var employee = await _db.Employees.Include(x => x.Credentials).Where(x => x.Credentials.Email == email).FirstAsync() ??
                           throw new EmployeeNotFoundException($"Employee with credential's email: {email} could not be found");
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            _ = employee ?? throw new EmployeeNullArgumentException();
            var employeeEntity = await GetEmployee(employeeId);
            employeeEntity.FullName = employee.FullName;
            await _db.SaveChangesAsync();
            return employeeEntity;
        }
    }
}
