using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactjs_api.Data;
using Reactjs_api.Models;
using Reactjs_api.Repositories;
using Reactjs_api.Repositories.Interfaces;
using Reactjs_api.Requests;
using Reactjs_api.Responses;

namespace Reactjs_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;
    
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    [Route("/users/get_users")]
    public GetUsersResponse GetUsers([FromQuery]GetUsersRequest request)
    {
        var response = _repository.GetUsers(request.Skip, request.Amount);
        return new GetUsersResponse(response, _repository.Length);
    }

    [HttpGet]
    [Route("/users/get_user/{userId}")]
    public async Task<IActionResult> GetUser(long userId)
    {
        var user = await _repository.GetUser(userId);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    [HttpPatch]
    [Route("/users/follow_user/{userId}")]
    public async Task<IActionResult> Follow(long userId)
    {
        var user = await _repository.GetUser(userId);
        if (user != null)
        {
            user.IsFollowed = true;
            await _repository.EditUser(user);
            return Ok();
        }
    
        return BadRequest();
    }
    
    [HttpPatch]
    [Route("/users/unfollow_user/{userId}")]
    public async Task<IActionResult> UnFollow(long userId)
    {
        var user = await _repository.GetUser(userId);
        if (user != null)
        {
            user.IsFollowed = false;
            await _repository.EditUser(user);
            return Ok();
        }
    
        return BadRequest();
    }

    [HttpPost]
    [Route("/users/set_status")]
    public async Task<IActionResult> SetStatus(SetStatusRequest request)
    {
        var user = await _repository.GetUser(request.UserId);
        if (user != null)
        {
            user.Status = request.Status;
            await _repository.EditUser(user);
            return Ok();
        }

        return BadRequest();
    }
}