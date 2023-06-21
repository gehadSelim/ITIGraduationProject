using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.DAL;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ValidatePermissionAttribute))]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeWriteDTO employeeDTO)
        {
            
            var result = await _employeeManager.AddAsync(employeeDTO);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveEmployees()
        {
            var result = await _employeeManager.GetAllActiveAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeManager.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var result = await _employeeManager.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("applicationUser/{id}")]
        public async Task<IActionResult> GetEmployeeByApplicationUserId(string id)
        {
            var result = await _employeeManager.GetByApplicationUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, EmployeeUpdateDTO employeeDTO)
        {
            employeeDTO.Id = id;
            var result = await _employeeManager.UpdateAsync(employeeDTO);
            return Ok(result);
        }

        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateEmployeeStatus(string id, EmployeeUpdateStatusDTO employeeDTO)
        {
            employeeDTO.Id = id;
            var result = await _employeeManager.UpdateStatusAsync(employeeDTO);
            return Ok(result);
        }
    }
}
