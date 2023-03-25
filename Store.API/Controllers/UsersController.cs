using Microsoft.AspNetCore.Mvc;
using Store.API.Models;
using Store.API.Services;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("allUser")]
    public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
    {
        var users = await _usersService.GetUsers();
        return Ok(users);
    }

    [HttpGet("UserId")]
    public async Task<ActionResult<Users>> GetUsersById(Guid userId)
    {
        var user = await _usersService.GetUsersById(userId);
        return user == null ? NotFound() : Ok(user);
    }


    [HttpPost("addUser")]
    public async Task<IActionResult> AddUsers(Users user)
    {
        await _usersService.AddUsers(user);
        return Ok();
    }
}

