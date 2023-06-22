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
        public async Task<ActionResult<IEnumerable<StateReadSimpleDTO>>> GetAllActiveStates()
        {
            var states = await _stateManager.GetAllActiveAsync();
            return Ok(states);
        }

        [HttpGet("paginate")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllStatesWithPagination(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _stateManager.GetAllWithPaginationAsync(pageNumber, pageSize));
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<IEnumerable<StateReadDTO>>> GetAllStates()
        {
            var states = await _stateManager.GetAllAsync();
            return Ok(states);
        }

        [HttpGet("HavingCities")]
        public async Task<ActionResult<IEnumerable<StateReadSimpleDTO>>> GetAllStatesHavingCities()
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


