using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManger _usersManger;
        public UsersController(IUsersManger usersManger)
        {
            _usersManger = usersManger;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDto)
        {

            var result = await _usersManger.Login(loginDto);
            if (result == null) { return BadRequest(result); }
            return result;
        }
    }
}
