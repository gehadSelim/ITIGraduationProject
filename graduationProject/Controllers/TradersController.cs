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
    public class TradersController : ControllerBase
    {
        private readonly ITraderManager _traderManager;

        public TradersController(ITraderManager traderManager)
        {
            _traderManager = traderManager;
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> AddTrader(TraderWriteDTO TraderDTO)
        {

            var result = await _traderManager.AddAsync(TraderDTO);
            return Ok(result);
        }

        [HttpGet("active")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllActiveTraders()
        {
            var result = await _traderManager.GetAllActiveAsync();
            return Ok(result);
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllTraders()
        {
            var result = await _traderManager.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetTraderById(string id)
        {
            var result = await _traderManager.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("applicationUser/{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetTraderByApplicationUserId(string id)
        {
            var result = await _traderManager.GetByApplicationUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> UpdateTrader(string id, TraderUpdateDTO TraderDTO)
        {
            TraderDTO.Id = id;
            var result = await _traderManager.UpdateAsync(TraderDTO);
            return Ok(result);
        }

        [HttpDelete("specialPackage/{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public IActionResult DeleteSpecialPackage(int id)
        {
            _traderManager.DeleteTraderSpecialPackages(id);
            return NoContent();
        }
    }
}
