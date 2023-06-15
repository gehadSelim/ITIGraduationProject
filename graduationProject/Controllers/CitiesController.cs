﻿using graduationProject.Bl.DTOs.CityDTO;
using graduationProject.Bl.Managers.CityManager;
using graduationProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityManager _cityManager;

        public CitiesController(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> AddCity(CityWriteDto cityDto)
        {
            var result = await _cityManager.AddAsync(cityDto);
            return Ok(result);
        }

        [HttpGet("{stateName}")]
        public async Task<IActionResult> GetAllCities(string stateName)
        {
            var cities = await _cityManager.GetAllAsync(stateName);
            return Ok(cities);
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(ValidatePermissionAttribute))]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        {
            cityDto.Id = id;
            var result = await _cityManager.UpdateAsync(cityDto);
            return Ok(result);
        }
    }
}