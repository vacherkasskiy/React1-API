using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Reactjs_api.Models;

namespace Reactjs_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private static LoginUser[] users =
    {
        new LoginUser("vacherkasskiy", "123456"),
        new LoginUser("spacex", "abcdef"),
        new LoginUser("amazon", "bezos"),
    };

    [HttpPost]
    [Route("/auth/login")]
    public async Task<IActionResult> Login([FromQuery]LoginUser request)
    {
        var user = users
            .FirstOrDefault(x => 
                x.Login == request.Login &&
                x.Password == request.Password);

        if (user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Wrong login or password");
        }
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Login),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return StatusCode(StatusCodes.Status200OK, "Success");
    }

    [HttpGet]
    [Route("/auth/get")]
    public IActionResult GetUser()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, "User is not authenticated");
        }

        return StatusCode(StatusCodes.Status200OK, User.Identity!.Name);
    }
}