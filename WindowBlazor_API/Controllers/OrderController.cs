using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WindowBlazor_Business.Repository.IRepository;
using WindowBlazor_Models;

namespace WindowBlazor_API.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objList = await _orderRepository.GetAll();
            return Ok(objList);
        }

        [HttpGet("{orderHeaderId}")]
        public async Task<IActionResult> Get(int? orderHeaderId)
        {
            if (orderHeaderId == null || orderHeaderId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    Title = "Error",
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
            var orderHeader = await _orderRepository.Get(orderHeaderId.GetValueOrDefault());
            if (orderHeader == null)
            {
                return NotFound(new ErrorModelDTO()
                {
                    Title = "Error",
                    ErrorMessage = "Order object was not found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(orderHeader);
        }
    }
}
