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
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null) 
                {
                    return NotFound();
                }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee (EmployeeDTO dTO)
        {
            var employee = await _employeeService.AddEmployee(dTO);
            return CreatedAtAction
                (
                    nameof(GetEmployeeById),
                    new {id = employee.Id},
                    employee
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, EmployeeDTO dTO)
        {
            var employee = await _employeeService.UpdateEmployee(id, dTO);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
