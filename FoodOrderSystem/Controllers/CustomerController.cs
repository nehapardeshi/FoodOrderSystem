using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddUserRequest request)
        {
            var id = await _customerService.AddCustomerAsync(request.FirstName, request.LastName, request.Email, request.Phone, request.Address, request.City);
            return Ok(id);
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> GetCustomerAsync([FromRoute] int customerId)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);
            return Ok(customer);
        }

        [HttpPut]
        [Route("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync(int customerId, [FromBody] UpdateUserRequest request)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);
            if (customerId == null)
                return BadRequest($"Customer not found with this id: {customerId}");

            customer = await _customerService.UpdateCustomerAsync(customerId, request.FirstName, request.LastName, request.Email, request.Phone, request.Address, request.City);
            return Ok(customer);

        }

        [HttpDelete]
        [Route("{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync(int customerId)
        {
            var customer = await (_customerService.GetCustomerAsync(customerId));
            if (customer == null)
            {
                return BadRequest($"Customer not found with this id: {customerId}");
            }
            await _customerService.DeleteCustomerAsync(customerId);
            return Ok();
        }
    }
}
