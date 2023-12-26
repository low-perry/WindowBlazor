using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WindowBlazor_Business.Repository.IRepository;
using WindowBlazor_Models;

namespace WindowBlazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowRepository _windowRepository;
        public WindowController(IWindowRepository windowRepository)
        {
            _windowRepository = windowRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objList = await _windowRepository.GetAll();
            return Ok(objList);
        }

        [HttpGet("{windowId}")]
        public async Task<IActionResult> Get(int? windowId)
        {
            if (windowId == null || windowId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    Title = "Error",
                    ErrorMessage = "Inalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
            var obj = await _windowRepository.Get(windowId.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound(new ErrorModelDTO()
                {
                    Title = "Error",
                    ErrorMessage = "Window object was not found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(obj);
        }
    }
}
