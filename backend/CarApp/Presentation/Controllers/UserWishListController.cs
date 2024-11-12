using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Car.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWishListController : ControllerBase
    {
        private readonly IVehicleWishListService _vehicleWishListService;
        public UserWishListController(IVehicleWishListService vehicleWishListService)
        {
            _vehicleWishListService = vehicleWishListService;
        }

        [HttpGet("GetUserWishList")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> GetUserWishList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized("User Not Found");
            var wishList = await _vehicleWishListService.GetUserWishListAsync(userId);
            return Ok(wishList);
        }
        [HttpPost("AddVehicleToWishList")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> AddVehicleToWishList([FromBody]string vehicleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized("User Not Found");
            var result=await _vehicleWishListService.AddVehicleToWishListAsync(userId, vehicleId);
            return Ok(result);
        }

        [HttpPost("RemoveVehicleToWishList")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> RemoveVehicleToWishList([FromBody]string vehicleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized("User Not Found");
            await _vehicleWishListService.RemoveVehicleToWishListAsync(userId, vehicleId);
            return Ok();
        }


    }
}
