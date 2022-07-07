using AutoMapper;
using Business.Models;
using Business.Services;
using MeetupApp.Request;
using MeetupApp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetupApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserService<int> _userService;

        public UserController(IMapper mapper, IUserService<int> userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usersModels = await _userService.GetAllAsync();
            var users = _mapper.Map<List<UserModel>, List<UserResponse>>(usersModels);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var userModel = await _userService.GetAsync(id);
            var user = _mapper.Map<UserModel, UserResponse>(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserRequest updatedUser)
        {
            var user = _mapper.Map<UserRequest, UserModel>(updatedUser);
            await _userService.UpdateAsync(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
