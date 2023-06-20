using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactjs_api.Data;
using Reactjs_api.Models;
using Reactjs_api.Requests;
using Reactjs_api.Responses;

namespace Reactjs_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    
    public UserController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    [Route("/users/get_users")]
    public GetUsersResponse GetUsers([FromQuery]GetUsersRequest request)
    {
        var response = _db.Users
            .Skip(request.Skip)
            .Take(request.Amount)
            .ToArray();

        return new GetUsersResponse(response, _db.Users.ToArray().Length);
    }

    [HttpGet]
    [Route("/users/get_user/{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    [HttpPatch]
    [Route("/users/follow_user/{userId}")]
    public async Task<IActionResult> Follow(int userId)
    {
        var user = await _db.Users.FindAsync(userId);

        if (user != null)
        {
            user.IsFollowed = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    
        return StatusCode(StatusCodes.Status400BadRequest);
    }
    
    [HttpPatch]
    [Route("/users/unfollow_user/{userId}")]
    public async Task<IActionResult> UnFollow(int userId)
    {
        var user = await _db.Users.FindAsync(userId);

        if (user != null)
        {
            user.IsFollowed = false;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK);
        }
    
        return StatusCode(StatusCodes.Status400BadRequest);
    }

}