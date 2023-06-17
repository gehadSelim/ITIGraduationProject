using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [ApiController]
    [Route("api/states")]
    [Authorize]
    public class StatesController : ControllerBase
    {
        private readonly IStateManager _stateManager;

        public StatesController(IStateManager stateManager)
        {
            _stateManager = stateManager;

        }

        [HttpPost]

        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<StateWriteDTO>> AddState(StateWriteDTO stateDTO)
        {
            var newState = await _stateManager.AddAsync(stateDTO);
            return Ok(newState);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<StateReadDTO>>> GetAllActiveStates()
        {
            var states = await _stateManager.GetAllActiveAsync();
            return Ok(states);
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<IEnumerable<StateReadDTO>>> GetAllStates()
        {
            var states = await _stateManager.GetAllAsync();
            return Ok(states);
        }

        [HttpGet("HavingCities")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<IEnumerable<StateReadDTO>>> GetAllStatesHavingCities()
        {
            var states = await _stateManager.GetAllHavingCitiesAsync();
            return Ok(states);
        }

        [HttpGet("cities/{id}")]
        public async Task<ActionResult<StateReadDTO>> GetStateByIdWithCities(int id)
        {
            var state = await _stateManager.GetStateByIdWithCitiesAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<StateUpdateDTO>> UpdateState(byte id, StateUpdateDTO stateDTO)
        {
            stateDTO.Id = id;
            var updatedState = await _stateManager.UpdateAsync(stateDTO);
            return Ok(updatedState);
        }

        [HttpGet("totalPages")]
        public IActionResult GetTotalPages(int pageSize)
        {
            return Ok(_stateManager.GetTotalPages(pageSize));
        }
    }
}


