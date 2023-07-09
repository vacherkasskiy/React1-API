using System.ComponentModel.DataAnnotations;

namespace Reactjs_api.Data.Models;

public class User
{
    [Key] public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string? Birthday { get; set; }
    public string? City { get; set; }
    public string? Education { get; set; }
    public string? Website { get; set; }
    public string? Status { get; set; }
    public string? Image { get; set; } =
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToK_-LT9HmxfBNTsC0A8wfvjtfxKh3GjexbQ&usqp=CAU";
    public bool IsFollowed { get; set; } = false;
}