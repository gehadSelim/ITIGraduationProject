using graduationProject.Bl.DTOs;
using graduationProject.Bl.Managers;
using graduationProject.Bl.Managers.OrderManager;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchManager _branchManager;

        public BranchesController(IBranchManager branchManager)
        {
            _branchManager = branchManager;
        }

        [HttpGet]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<IEnumerable<BranchReadDTO>>> GetAllBranches()
        {
            var branches = await _branchManager.GetAllAsync();
            return Ok(branches);
        }

        [HttpGet("paginate")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> GetAllBranchesWithPagination( int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _branchManager.GetAllWithPaginationAsync(pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchReadDTO>> GetBranchById(byte id)
        {
            var branch = await _branchManager.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            return Ok(branch);
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<BranchWriteDTO>> AddBranch(BranchWriteDTO branchDto)
        {
            var newBranch = await _branchManager.AddAsync(branchDto);
            return Ok(newBranch);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<ActionResult<BranchUpdateDTO>> UpdateBranch(byte id, BranchUpdateDTO branchDto)
        {
            branchDto.Id = id;
            var updatedBranch = await _branchManager.UpdateAsync(branchDto);
            return Ok(updatedBranch);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<BranchReadDTO>>> GetAllActiveBranches()
        {
            var branches = await _branchManager.GetAllActiveAsync();
            return Ok(branches);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public IActionResult DeleteBranch(byte id)
        {
            _branchManager.Delete(id);
            return NoContent();
        }
    }
}
