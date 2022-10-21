using BugTracker.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            return Ok(loginRequest);
        }
    };
}
