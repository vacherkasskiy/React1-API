namespace Reactjs_api.Models;

public record User(
    long Id,
    string Name,
    string Birthday,
    string City,
    string Education,
    string Website,
    string Image,
    bool IsFollowed = false);