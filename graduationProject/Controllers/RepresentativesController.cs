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
    public class RepresentativesController : ControllerBase
    {
        private readonly IRepresentativeManager _representativeManager;

        public RepresentativesController(IRepresentativeManager representativeManager)
        {
            _representativeManager = representativeManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddRepresentative(RepresentativeWriteDTO RepresentativeDTO)
        {

            var result = await _representativeManager.AddAsync(RepresentativeDTO);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveRepresentatives()
        {
            var result = await _representativeManager.GetAllActiveAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRepresentatives()
        {
            var result = await _representativeManager.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("paginate")]
        public async Task<IActionResult> GetAllRepresentativesWithPagination(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _representativeManager.GetAllWithPaginationAsync(pageNumber, pageSize));
        }

        [HttpGet("state/{id}")]
        public async Task<IActionResult> GetAllRepresentativesByStateId(int id)
        {
            var result = await _representativeManager.GetAllActiveByStateIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepresentativeById(string id)
        {
            var result = await _representativeManager.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("applicationUser/{id}")]
        public async Task<IActionResult> GetRepresentativeByApplicationUserId(string id)
        {
            var result = await _representativeManager.GetByApplicationUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepresentative(string id, RepresentativeUpdateDTO RepresentativeDTO)
        {
            RepresentativeDTO.Id = id;
            var result = await _representativeManager.UpdateAsync(RepresentativeDTO);
            return Ok(result);
        }

        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateRepresentativeStatus(string id, RepresentativeUpdateStatusDTO RepresentativeDTO)
        {
            RepresentativeDTO.Id = id;
            var result = await _representativeManager.UpdateStatusAsync(RepresentativeDTO);
            return Ok(result);
        }
    }
}
