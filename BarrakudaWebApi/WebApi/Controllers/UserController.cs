using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserContextService _userContextService;

        public UserController(IUserContextService userContextService)
        {
            _userContextService = userContextService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetUserName()
        {
            var userName = _userContextService.GetUserName;
            return Ok(userName);
        }
    }
}
