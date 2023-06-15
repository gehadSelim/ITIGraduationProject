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
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsManager _settingsManager;

        public SettingsController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<SettingsReadDTO>> GetAllSettings()
        {
            var settings = await _settingsManager.GetAsync();
            return Ok(settings);
        }


        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<SettingsUpdateDTO>> UpdateSettings(byte id, SettingsUpdateDTO settingsDto)
        {
            settingsDto.Id= 1;
            var updatedSettings = await _settingsManager.UpdateAsync(settingsDto);
            return Ok(updatedSettings);
        }

    }
}
