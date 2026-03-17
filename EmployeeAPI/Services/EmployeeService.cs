using EmployeeAPI.Models;
using EmployeeAPI.DTOs;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;


namespace EmployeeAPI.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public async Task<Employee> AddEmployee(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Department = dto.Department
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployee(int id, EmployeeDTO dto)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }
            employee.Name = dto.Name;
            employee.Department = dto.Department;
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return false;
            }
            _context.Employees.Remove(employee);
            return true;
        }
        
    }
}
