using AutoMapper;
using Business.Models;
using Business.Services;
using MeetupApp.Request;
using MeetupApp.Response;
using Microsoft.AspNetCore.Mvc;

namespace MeetupApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegistrationRequest registrationRequest)
        {
            var model = _mapper.Map<RegistrationRequest, RegistrationModel>(registrationRequest);
            await _authService.RegisterUserAsync(model);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginRequest loginRequest)
        {
            var model = _mapper.Map<LoginRequest, LoginModel>(loginRequest);
            var successModel = await _authService.LoginUserAsync(model);
            var response = _mapper.Map<LoginSuccessModel, LoginResponse>(successModel);

            return Ok(response);
        }
    }

}
