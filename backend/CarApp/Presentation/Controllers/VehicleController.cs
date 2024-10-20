using Car.Application.Services;
using Car.Domain.DTO_s;
using Car.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult>AddVehicle([FromBody]VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null) return BadRequest("Invalid Vehicle!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!"); 
            else await _vehicleService.AddVehicleAsync(vehicleDTO,userId);
            return Ok("Vehicle created succesfully...");
        }
        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> GetAllVehicles(int page,int size)
        {
            var vehicles= await _vehicleService.GetVehicleAsync(page,size);
            return Ok(vehicles);
        }

        [HttpDelete("RemoveVehicle")]
        public async Task<IActionResult> RemoveVehicle([FromBody]string vehicleId)
        {
            if (vehicleId == null) return BadRequest("Vehicles Empty!");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return Unauthorized("User Not Authenticated!");
            else await _vehicleService.RemoveVehicleAsync(vehicleId);
            return Ok($"Vehicle with {vehicleId} removed successfully!");
        }

        [HttpPut("UpdateVehicle")]
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
    }
}
