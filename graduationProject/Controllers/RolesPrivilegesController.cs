using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.DAL.Data.Models;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesPrivilegesController : ControllerBase
    {
        private readonly IRolesManager _roleManager;

        public RolesPrivilegesController(IRolesManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.GetAll();
            return Ok(roles);
        }

        [HttpGet]
        public IActionResult GetAllSimpleRoles()
        {
            var roles = _roleManager.GetAllSimple();
            return Ok(roles);
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> CreateRole(RoleWriteDTO role)
        {
            var result = await _roleManager.AddAsync(role);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> UpdateRole(string id, RoleUpdateDTO role)
        {
            role.RoleId = id;

            var result = await _roleManager.UpdateAsync(role);

            if (result != null)
            {
                return Ok(role);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleManager.DeleteAsync(id);
            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }
    }
}


