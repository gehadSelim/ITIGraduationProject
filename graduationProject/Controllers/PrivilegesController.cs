using graduationProject.Bl.DTO;
using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ValidatePermissionAttribute))]
    public class PrivilegesController : ControllerBase
    {
        private readonly IPrivilegeManger _privilegeManager;

        public PrivilegesController(IPrivilegeManger privilegeManager)
        {
            _privilegeManager = privilegeManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivilegeReadDTO>>> GetAllPrivileges()
        {
            var privileges = await _privilegeManager.GetAllAsync();
            return Ok(privileges);
        }

    }
}
