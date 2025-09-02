using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace FoodOrderSystem.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]

        public async Task<IActionResult> AddAdminAsync([FromBody]AddUserRequest request)
        {
            var id = await _adminService.AddAdminAsync(request.FirstName, request.LastName, request.Email, request.Address, request.Phone, request.City);
            return Ok(id);
        }
        [HttpGet]
        [Route("{adminId}")]
        public async Task <IActionResult> GetAdminAsync([FromRoute] int adminId)
        {
            var admin = await _adminService.GetAdminAsync(adminId);
            return Ok(admin);
        }

        [HttpPut]
        [Route("{adminId}")]
        public async Task<IActionResult> UpdateAdminAsync(int adminId, [FromBody] UpdateUserRequest request)
        {
            var admin = await _adminService.GetAdminAsync(adminId);
            if (admin == null)
            {
                return BadRequest($"admin not found with this id: {adminId}");
            }
            admin = await _adminService.UpdateAdminAsync(adminId, request.FirstName, admin.LastName, admin.Email, request.Phone, request.Address, request.City);
            return Ok(admin);
        }
        [HttpDelete]
        [Route("{adminId}")]
        public async Task<IActionResult> DeleteAdminAsync([FromRoute] int adminId)
        {
            var admin = await _adminService.GetAdminAsync(adminId);
            if (admin == null)
                return BadRequest($"Admin not found with this id: {adminId}");
            await _adminService.DeleteAdminAsync(adminId);
            return Ok();
        }


    }
}
