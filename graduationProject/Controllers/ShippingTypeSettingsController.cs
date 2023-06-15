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
    public class ShippingTypeSettingsController : ControllerBase
    {
        private readonly IShippingTypeManager _shippingTypeManager;

        public ShippingTypeSettingsController(IShippingTypeManager shippingTypeManager)
        {
            _shippingTypeManager = shippingTypeManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingTypeReadDTO>>> GetAllShippingTypes()
        {
            var shippingTypes = await _shippingTypeManager.GetAllAsync();
            return Ok(shippingTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingTypeReadDTO>> GetShippingTypeById(byte id)
        {
            var shippingType = await _shippingTypeManager.GetByIdAsync(id);
            if (shippingType == null)
                return NotFound();

            return Ok(shippingType);
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<ShippingTypeWriteDTO>> AddShippingType(ShippingTypeWriteDTO shippingTypeDto)
        {
            var newShippingType = await _shippingTypeManager.AddAsync(shippingTypeDto);
            return Ok(newShippingType);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<ShippingTypeUpdateDTO>> UpdateShippingType(byte id, ShippingTypeUpdateDTO shippingTypeDto)
        {
            shippingTypeDto.Id = id;
            var updatedShippingType = await _shippingTypeManager.UpdateAsync(shippingTypeDto);
            return Ok(updatedShippingType);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public IActionResult DeleteShippingType(byte id)
        {
            _shippingTypeManager.Delete(id);
            return NoContent();
        }
    }
}
