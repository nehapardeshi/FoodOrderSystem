using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    [Route("api/chefs")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IChefService _chefService;

        public ChefsController(IChefService chefService)
        {
            _chefService = chefService;
        }

        [HttpPost]
        public async Task<IActionResult> AddChefAsync([FromBody] AddUserRequest request)
        {
            var id = await _chefService.AddChefAsync(request.FirstName, request.LastName, request.Email, request.Phone, request.Address, request.City);
            return Ok(id);
        }
        [HttpGet]
        [Route("{chefId}")]
        public async Task<IActionResult> GetChefAsync(int chefId)
        {
            var chef = await _chefService.GetChefAsync(chefId);
            return Ok(chef);
        }
        [HttpPut]
        [Route("{chefId}")]
        public async Task<IActionResult> UpdateChefAsync(int chefId, [FromBody] UpdateUserRequest request)
        {
            var chef = await _chefService.GetChefAsync(chefId);
            if (chef == null)
                return BadRequest($"Chef not found with this id: {chefId}");

            chef = await _chefService.UpdateChefAsync(chefId, request.FirstName, request.LastName, request.Email, request.Phone, request.Address, request.City);
            return Ok(chef);
        }

        [HttpDelete]
        [Route("{chefId}")]
        public async Task<IActionResult> DeleteChefAsync(int chefId)
        {
            var chef = await _chefService.GetChefAsync(chefId);
            if (chef == null)
                return BadRequest($"Chef not found with this id: {chefId}");
            await _chefService.DeleteChefAsync(chefId);
            return Ok(chef);
        }
    }
}
