using Reactjs_api.Models;

namespace Reactjs_api.Responses;

public record GetUsersResponse(
    User?[] Users,
    int UsersAmount);