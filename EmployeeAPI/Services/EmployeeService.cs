using EmployeeAPI.Models;
using EmployeeAPI.DTOs;



namespace EmployeeAPI.Services
{
    public class EmployeeService
    {
       private static List<Employee> employees = new List<Employee>();
        private static int _id = 1;

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee AddEmployee(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                Id = _id++,
                Name = dto.Name,
                Department = dto.Department
            };
            employees.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(int id, EmployeeDTO dto)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }
            employee.Name = dto.Name;
            employee.Department = dto.Department;
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return false;
            }
            employees.Remove(employee);
            return true;
        }
        
    }
}
