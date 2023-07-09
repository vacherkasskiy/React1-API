using Microsoft.AspNetCore.Mvc;
using Reactjs_api.Data.Models;
using Reactjs_api.Repositories.Interfaces;
using Reactjs_api.Requests;

namespace Reactjs_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserRepository _repository;
    public AccountController(IUserRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    [Route("/auth/register")]
    public async Task<IActionResult> GetValues(RegisterRequest request)
    {
        if (_repository
                .GetUsers(0, _repository.Length)
                .Any(x => x.Email == request.Email))
        {
            return BadRequest("Wrong email");
        }
        
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
        };
        await _repository.AddUser(user);
        
        return Ok(request);
    }
}