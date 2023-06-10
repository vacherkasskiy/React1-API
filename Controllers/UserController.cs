using Microsoft.AspNetCore.Mvc;
using Reactjs_api.Models;
using Reactjs_api.Requests;
using Reactjs_api.Responses;

namespace Reactjs_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static User[] users =
    {
        new User(
            0,
            "Cherkasskiy Vitaliy",
            "4th September",
            "Moscow",
            "HSE '25",
            "https://github.com/vacherkasskiy",
            "https://res.cloudinary.com/jerrick/image/upload/c_scale,f_jpg,q_auto/jrsbekxaroxa3r7wxvfc.jpg"
        ),
        new User(
            1,
            "Elon Musk",
            "30th November",
            "London",
            "MIT",
            "https://spacex.com",
            "https://cdn1.tenchat.ru/static/vbc-gostinder/user-picture/0f109e74-e513-40ef-a21f-7df492f192e7.jpeg"
        ),
        new User(
            2,
            "Jeff Bezos",
            "12 January",
            "New Mexico",
            "MIT",
            "https://amazon.com",
            "https://assets.wired.com/photos/w_1720/wp-content/uploads/2019/01/Culture_GeeksGuide_Bezos.jpg"
        ),
        new User(
            3,
            "Bill Gates",
            "28th October",
            "Washington",
            "MIT",
            "https://microsoft.com",
            "https://media.cnn.com/api/v1/images/stellar/prod/230124093557-bill-gates-file-081822.jpg?c=16x9&q=h_720,w_1280,c_fill"
        ),
        new User(
            4,
            "Cherkasskiy Vitaliy",
            "4th September",
            "Moscow",
            "HSE '25",
            "https://github.com/vacherkasskiy",
            "https://res.cloudinary.com/jerrick/image/upload/c_scale,f_jpg,q_auto/jrsbekxaroxa3r7wxvfc.jpg"
        ),
        new User(
            5,
            "Elon Tusk",
            "30th November",
            "London",
            "Idk where I educated lmao",
            "https://spacex.com",
            "https://cdn1.tenchat.ru/static/vbc-gostinder/user-picture/0f109e74-e513-40ef-a21f-7df492f192e7.jpeg"
        ),
        new User(
            6,
            "Egor Cringe",
            "12 January",
            "New Mexico",
            "MIT",
            "https://amazon.com",
            "https://assets.wired.com/photos/w_1720/wp-content/uploads/2019/01/Culture_GeeksGuide_Bezos.jpg"
        ),
        new User(
            7,
            "Bill Gates",
            "28th October",
            "Washington",
            "MIT",
            "https://microsoft.com",
            "https://media.cnn.com/api/v1/images/stellar/prod/230124093557-bill-gates-file-081822.jpg?c=16x9&q=h_720,w_1280,c_fill"
        ),
        new User(
            8,
            "Cherkasskiy Vitaliy",
            "4th September",
            "Moscow",
            "HSE '25",
            "https://github.com/vacherkasskiy",
            "https://res.cloudinary.com/jerrick/image/upload/c_scale,f_jpg,q_auto/jrsbekxaroxa3r7wxvfc.jpg"
        ),
        new User(
            9,
            "Elon Musk",
            "30th November",
            "London",
            "Idk where I educated lmao",
            "https://spacex.com",
            "https://cdn1.tenchat.ru/static/vbc-gostinder/user-picture/0f109e74-e513-40ef-a21f-7df492f192e7.jpeg"
        ),
        new User(
            10,
            "Jeff Bezos",
            "12 January",
            "New Mexico",
            "MIT",
            "https://amazon.com",
            "https://assets.wired.com/photos/w_1720/wp-content/uploads/2019/01/Culture_GeeksGuide_Bezos.jpg"
        ),
        new User(
            11,
            "Bill Cakes",
            "28th October",
            "Washington",
            "MIT",
            "https://microsoft.com",
            "https://media.cnn.com/api/v1/images/stellar/prod/230124093557-bill-gates-file-081822.jpg?c=16x9&q=h_720,w_1280,c_fill"
        ),
        new User(
            12,
            "Cherkasskiy Vitaliy",
            "4th September",
            "Moscow",
            "HSE '25",
            "https://github.com/vacherkasskiy",
            "https://res.cloudinary.com/jerrick/image/upload/c_scale,f_jpg,q_auto/jrsbekxaroxa3r7wxvfc.jpg"
        ),
    };
    
    [HttpGet]
    [Route("/users/get_users")]
    public GetUsersResponse GetUsers([FromQuery]GetUsersRequest request)
    {
        var response = users
            .Skip(request.Skip)
            .Take(request.Amount)
            .ToArray();

        return new GetUsersResponse(response, users.Length);
    }

    [HttpGet]
    [Route("/users/get_user/{userId}")]
    public IActionResult GetUser(int userId)
    {
        var user = users.FirstOrDefault(x => x.Id == userId);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    [HttpPatch]
    [Route("/users/follow_user/{userId}")]
    public IActionResult Follow(int userId)
    {
        var user = users.FirstOrDefault(x => x.Id == userId);
        var index = Array.IndexOf(users, user);

        if (user != null)
        {
            users[index] = user with { IsFollowed = true };
            return StatusCode(StatusCodes.Status200OK);
        }
    
        return StatusCode(StatusCodes.Status400BadRequest);
    }
    
    [HttpPatch]
    [Route("/users/unfollow_user/{userId}")]
    public IActionResult UnFollow(int userId)
    {
        var user = users.FirstOrDefault(x => x.Id == userId);
        var index = Array.IndexOf(users, user);

        if (user != null)
        {
            users[index] = user with { IsFollowed = false };
            return StatusCode(StatusCodes.Status200OK);
        }
    
        return StatusCode(StatusCodes.Status400BadRequest);
    }

}