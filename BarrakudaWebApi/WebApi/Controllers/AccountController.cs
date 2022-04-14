namespace WebApi.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService userService)
        {
            _accountService = userService;
        }

        [SwaggerOperation(Summary = "Register a new user")]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterDto userDto)
        {
            await _accountService.CreateUser(userDto);
            return Ok();
        }

        [SwaggerOperation(Summary = "Login to user account")]
        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            string token = await _accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
}
