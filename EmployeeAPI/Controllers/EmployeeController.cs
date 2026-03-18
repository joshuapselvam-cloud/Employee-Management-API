using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Services;
using EmployeeAPI.DTOs;
using EmployeeAPI.Models;



namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController (EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null) 
                {
                    return NotFound();
                }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<List<Employee>> AddEmployee (EmployeeDTO dTO)
        {
            var employee = _employeeService.AddEmployee(dTO);
            return CreatedAtAction
                (
                    nameof(GetEmployeeById),
                    new {id = employee.Id},
                    employee
                );
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, EmployeeDTO dTO)
        {
            var employee = _employeeService.UpdateEmployee(id, dTO);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
