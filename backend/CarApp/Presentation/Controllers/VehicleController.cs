﻿using Car.Application.Services;
using Car.Domain.DTO_s;
using Car.Domain.Enums.FuelTypes;
using Car.Domain.Enums.VehicleType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpPost("CreateVehicle")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult>AddVehicle([FromBody]VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null) return BadRequest("Invalid Vehicle!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!"); 
            else await _vehicleService.AddVehicleAsync(vehicleDTO,userId);
            return Ok("Vehicle created succesfully...");
        }
        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles(
            int page,
            int size,
            string? brand = null,
            VehicleType? vehicleType = null,
            FuelType? fuelType = null)
        {
            var (vehicles, totalCount) = await _vehicleService.GetVehicleAsync(
                page, size, brand, vehicleType, fuelType);

            return Ok(new
            {
                Vehicles = vehicles,
                TotalCount = totalCount
            });
        }

        [HttpGet("GetAllVehiclesList")]
        public async Task<IActionResult> GetAllVehiclesList()
        {
            var vehicles=await _vehicleService.GetAllVehiclesListAsync();
            return Ok(vehicles);
        }

        [HttpDelete("RemoveVehicle")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> RemoveVehicle([FromBody]string vehicleId)
        {
            if (vehicleId == null) return BadRequest("Vehicles Empty!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _vehicleService.RemoveVehicleAsync(vehicleId);
            return Ok($"Vehicle with {vehicleId} removed successfully!");
        }

        [HttpPut("UpdateVehicle")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateVehicle([FromBody]UpdateVehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null) return BadRequest("Invalid Vehicle!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _vehicleService.UpdateVehicleAsync(vehicleDTO,userId);
            return Ok($"Vehicle with {vehicleDTO.Id} updated successfully!");
        }
        [HttpGet("GetVehicleById")]
        public async Task<IActionResult> GetVehicleById([FromQuery]string vehicleId)
        {
            if (vehicleId == null) return BadRequest("Vehicles Empty!");
            var vehicle=await _vehicleService.GetVehicleByIdAsync(vehicleId);
            return Ok(vehicle);
        }
       
        [HttpPost("ClearAllVehicles")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ClearAllVehicles()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _vehicleService.ClearAllVehicles();
            return Ok("All Cars successfully Deleted Succesfully...");
        }

        [HttpGet("{vehicleId}/related")]
        public async Task<IActionResult>GetRelatedVehicles(string vehicleId,int page,int size)
        {
            if (vehicleId == null) return BadRequest("Vehicle Not Found!");
            var (vehicles,totalCount)=await _vehicleService.GetRelatedVehiclesAsync(vehicleId,page,size);
            return Ok(new
            {
                Vehicles=vehicles,
                TotalCount=totalCount
            });
        }
    }
}
